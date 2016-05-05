using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace AquaConsole
{
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
        /// <summary>
        /// Given an ip address or domain name, follow the trace path.
        /// 
        /// Idea and majority of the code from Jim Scott - http://coding.infoconex.com/post/C-Traceroute-using-net-framework.aspx
        /// </summary>
        /// <param name="ipAddressOrHostName">IP address or domain name to trace.</param>
        /// <param name="maximumHops">Maximum number of hops before quitting.</param>
        /// <returns>List of TraceLocation.</returns>
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