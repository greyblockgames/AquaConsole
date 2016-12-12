using PluginAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class trace : ICommand
    {
        public string Command
        {
            get
            {
                return "trace";
            }
        }


        public string HelpText
        {
            get
            {
                return "trace's the specified host.";
            }
        }


        public void CommandMethod(string[] p)
        {
            string path = string.Empty;
            for (int i = 0; i < p.Length; i++)
            {
                path = path + "" + p[i];
            }

            string IP;
            string SMaxHops;
            IP = path.Split(' ').First();
            SMaxHops = path.Remove(IP.IndexOf(IP), IP.Length).RemoveWhitespace();


            //Removes all non number characters from string 
            if (string.IsNullOrEmpty(Parse(SMaxHops.Trim())) || SMaxHops == "0")
            {
                SMaxHops = "10";
            }

            int MaxHops = Convert.ToInt32(Parse(SMaxHops.Trim()));

            try
            {
                Console.Write("Tracing " + IP + " [" + Dns.GetHostAddresses(IP)[0] + "], ");
                Console.WriteLine("Please Wait...");
                Console.WriteLine("");

                foreach (TraceLocation traceLocation in Trace.Traceroute(Dns.GetHostAddresses(IP)[0].ToString(), MaxHops))
                {
                    Console.Write(traceLocation.Hop + " ");
                    Console.Write(traceLocation.Time + "ms  ");
                    Console.Write(traceLocation.IpAddress + "   ");
                    if (!String.IsNullOrWhiteSpace(traceLocation.IpAddress) && !traceLocation.IpAddress.StartsWith("10.") && !traceLocation.IpAddress.StartsWith("192."))
                    {
                        try
                        {
                            Console.WriteLine(Dns.GetHostEntry(traceLocation.IpAddress).HostName.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Tracing request could not find host " + IP + " Please check the name and try again.");
            }
        }
        static string Parse(string source)
        {
            var numbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return new string(source.Where(x => numbers.Contains(x)).ToArray());
        }
    }


    public class TraceLocation
    {
        /// <summary>
        /// Hop number in a particular trace.
        /// </summary>
        public int Hop { get; set; }
        /// <summary>
        /// Time in milliseconds.
        /// </summary>
        public long Time { get; set; }
        /// <summary>
        /// IP address returned.
        /// </summary>
        public String IpAddress { get; set; }
    }

    public class Trace
    {

        public static List<TraceLocation> Traceroute(string ipAddressOrHostName, int maximumHops)
        {
            if (maximumHops < 1 || maximumHops > 100)
            {
                maximumHops = 30;
            }

            IPAddress ipAddress = Dns.GetHostEntry(ipAddressOrHostName).AddressList[0];

            List<TraceLocation> traceLocations = new List<TraceLocation>();

            using (Ping pingSender = new Ping())
            {
                PingOptions pingOptions = new PingOptions();
                Stopwatch stopWatch = new Stopwatch();
                byte[] bytes = new byte[32];
                pingOptions.DontFragment = true;
                pingOptions.Ttl = 1;

                for (int i = 1; i < maximumHops + 1; i++)
                {
                    TraceLocation traceLocation = new TraceLocation();

                    stopWatch.Reset();
                    stopWatch.Start();
                    PingReply pingReply = pingSender.Send(
                        ipAddress,
                        5000,
                        new byte[32], pingOptions);
                    stopWatch.Stop();

                    traceLocation.Hop = i;
                    traceLocation.Time = stopWatch.ElapsedMilliseconds;
                    if (pingReply.Address != null)
                    {
                        traceLocation.IpAddress = pingReply.Address.ToString();
                    }

                    traceLocations.Add(traceLocation);
                    traceLocation = null;

                    if (pingReply.Status == IPStatus.Success)
                    {
                        break;
                    }
                    pingOptions.Ttl++;
                }
            }
            return traceLocations;
        }
    }
}