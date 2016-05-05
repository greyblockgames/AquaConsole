using PluginAPI;
using System;
using System.Collections.Generic;
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


        public void CommandMethod(string p)
        {

            string IP;
            string SMaxHops;
            IP = p.Split(' ').First();
            SMaxHops = p.Remove(IP.IndexOf(IP), IP.Length).RemoveWhitespace();


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
}