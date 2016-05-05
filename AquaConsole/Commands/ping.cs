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
    class ping : ICommand
    {
        public string Command
        {
            get
            {
                return "ping";
            }
        }


        public string HelpText
        {
            get
            {
                return "Ping's the specified host.";
            }
        }


        public void CommandMethod(string p)
        {
            string IP;
            string SEchonum;
            IP = p.Split(' ').First();
            SEchonum = p.Remove(IP.IndexOf(IP), IP.Length).RemoveWhitespace();


            //Removes all non number characters from string 
            if (string.IsNullOrEmpty(Parse(SEchonum.Trim())) || SEchonum == "0")
            {
                SEchonum = "4";
            }

            int echonum = Convert.ToInt32(Parse(SEchonum.Trim()));
            try
            {
                IPAddress[] addresslist = Dns.GetHostAddresses(IP);


                Console.Write("Pinging " + IP + " [ ");
                foreach (IPAddress theaddress in addresslist)
                {
                    Console.Write(theaddress.ToString() + " ");
                }
                Console.Write("] ");
                Console.WriteLine("Please Wait...");
                Console.WriteLine("");

                foreach (IPAddress theaddress in addresslist)
                {
                    Ping(theaddress.ToString(), echonum);
                    Console.WriteLine("");
                    Utility.Wait(0.5F);
                }
            }
            catch
            {
                Console.WriteLine("Ping request could not find host " + IP + " Please check the name and try again.");
            }
        }


        static string Parse(string source)
        {
            var numbers = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return new string(source.Where(x => numbers.Contains(x)).ToArray());
        }



        public static void Ping(string host, int echoNum)
        {
            long totalTime = 0;
            int timeout = 120;
            Ping pingSender = new Ping();

            for (int i = 0; i < echoNum; i++)
            {
                PingReply reply = pingSender.Send(host, timeout);
                if (reply.Status == IPStatus.Success)
                {
                    totalTime += reply.RoundtripTime;
                }
                Console.WriteLine("Reply from " + host + " " + "Time=" + reply.RoundtripTime + "ms");
            }


            Console.WriteLine("Average: " + totalTime / echoNum);

        }

        
    }
}