using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PluginDownloader
{
    class xmlLoader
    {
        public static void Load(string p)
        {


            List<string> PluginName = new List<string>();
            List<string> PluginAuthor = new List<string>();
            List<string> PluginDescription = new List<string>();
            List<string> PluginURL = new List<string>();
            List<string> PluginHelpText = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(p + ".xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                //Loops through xml file and adds attributes to list's
                PluginName.Add(node.Attributes["name"]?.InnerText);
                PluginAuthor.Add(node.Attributes["author"]?.InnerText);
                PluginDescription.Add(node.Attributes["description"]?.InnerText);
                PluginURL.Add(node.InnerText);
            }

            //Creates list for interface
            foreach (string name in PluginName)
            {
                PluginHelpText.Add(PluginName + " " + PluginDescription + " " + PluginAuthor);
            }

            //Sorts list
            PluginHelpText.Sort();

            Console.Clear();



            //Full Screen
            Console.BufferWidth = Console.LargestWindowWidth;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;

            var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);

            //Begins creating menu
            var offset = PluginHelpText.Max(s => s.Length / 2);
            var formatString = "{0,-" + offset + "}     {1,-" + offset + "}    {2}";



            Console.WriteLine(formatString, "  ======", "=============", "========");
            Console.WriteLine(formatString, "   Name ", " Description", " Author");
            Console.WriteLine(formatString, "  ======", "=============", "========");


            int counter = 0;
            foreach (string name in PluginName)
            {
                //TODO: Check if plugin already exists

                counter++;
                Console.WriteLine(formatString, counter.ToString() + ") " + PluginName[counter - 1], PluginDescription[counter - 1], PluginAuthor[counter - 1]);
            }

            counter++;
            Console.WriteLine(formatString, counter.ToString() + ") ", "Exits the menu", null);

            //Takes Input   
            int selection;
        selection:
            Console.WriteLine();
            int.TryParse(Utility.SameLineTextInput("Please make a selection"), out selection);
            if (selection == PluginName.Count + 1)
            {
                goto exit;
            }
            else if (selection < 1 || selection >= PluginName.Count + 1)
            {
                Utility.ErrorWriteLine("Please ensure that your selection is in range and try again!");
                goto selection;
            }
            else
            {


                //Try download
                try
                {
                    string updurl = PluginURL[selection - 1];
                    WebClient WC = new WebClient();
                    WC.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WC_DownloadProgressChanged);
                    WC.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(WC_DownloadFileCompleted);
                    WC.DownloadFileAsync(new Uri(updurl), "/plugins/" + PluginName[selection - 1]);


                    //TODO: Make note file
                    Utility.WriteNotice("Plugin " + PluginName[selection - 1] + " has been installed successfully!");


                    //Restarts application to load plugin
                    Utility.RestartProgram();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }



            }




        exit:
            Console.Clear();


        }

        static void WC_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.UserState != e.Error)
            {
                Console.Clear();
                Console.WriteLine("Update applied successfully!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else { }
        }

        static void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine("Downloading Updated files...");
            Console.WriteLine(e.ProgressPercentage.ToString() + "%");
        }

    }
}