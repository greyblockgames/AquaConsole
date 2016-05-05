using PluginAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AquaConsole.Commands
{
    class PluginStorea : ICommand
    {

        private static List<string> PluginName = new List<string>();
        private static List<string> PluginAuthor = new List<string>();
        private static List<string> PluginDescription = new List<string>();
        private static List<string> PluginURL = new List<string>();
        private static List<string> PluginHelpText = new List<string>();


        public string Command
        {
            get
            {
                return "PM";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.pluginmanagerhelp;
            }
        }



        public void CommandMethod(string p)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("https://raw.githubusercontent.com/lukasdragon/AquaConsolePlugins/master/plugins.xml");
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    //Loops through xml file and adds any non installed plugin's attributes to list's
                    if (!GlobalLists.LoadedPlugins.Contains(node.Attributes["name"]?.InnerText))
                    {
                        PluginName.Add(node.Attributes["name"]?.InnerText);
                        PluginAuthor.Add(node.Attributes["author"]?.InnerText);
                        PluginDescription.Add(node.Attributes["description"]?.InnerText);
                        PluginURL.Add(node.InnerText);
                    }
                }


                //Fills List for gui text length
                foreach (string name in PluginName)
                {
                    PluginHelpText.Add(PluginName + " " + PluginDescription + " " + PluginAuthor);
                }

                PluginHelpText.Add(" " + " " + "Exits the menu" + " " + " ");


                Console.Clear();



                //Full Screen
                FullScreen();
                //Creates GUI
                CreateGUI();


                //Grabs Input   
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
                    //Downloads file
                    try
                    {
                        string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                        WebClient client = new WebClient();
                        Uri ur = new Uri(PluginURL[selection - 1]);

                        Console.WriteLine("Started download, please wait...");
                        // client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                        // client.DownloadDataCompleted += WebClientDownloadCompleted;
                        client.DownloadFile(ur, @exeDir + @"\plugins\" + PluginName[selection - 1] + ".dll");




                        //Makes a notice
                        Utility.WriteNotice("Plugin " + PluginName[selection - 1] + " has been installed successfully!");
                        Console.WriteLine("Plugin " + PluginName[selection - 1] + " has been downloaded successfully! Now Restarting");
                        Utility.Wait(0.25F);

                        //Restarts application to load plugin
                        Utility.RestartProgram();
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Unable to download file");
                        Utility.Wait(1);
                    }
                }




            exit:
                Utility.RestartProgram();
            }
            catch
            {
                Utility.ErrorWriteLine("Please check your internet connection and try again!");
            }

        }



        //Creates the gui
        static void CreateGUI()
        {
            var offset = PluginHelpText.Max(s => s.Length / 2);
            var formatString = "{0,-" + offset + "}     {1,-" + offset + "}    {2}";
            Console.WriteLine(formatString, "  ======", "=============", "========");
            Console.WriteLine(formatString, "   Name ", " Description", " Author");
            Console.WriteLine(formatString, "  ======", "=============", "========");
            int counter = 0;
            foreach (string name in PluginName)
            {
                counter++;
                Console.WriteLine(formatString, counter.ToString() + ") " + PluginName[counter - 1], PluginDescription[counter - 1], PluginAuthor[counter - 1]);
            }
            counter++;
            Console.WriteLine(formatString, counter.ToString() + ") ", "Exits the menu", null);
        }


        //makes console window fullscreen
        static void FullScreen()
        {
            Console.BufferWidth = Console.LargestWindowWidth;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);
        }

        //Download callback methods

        static void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Download status: {0}%.", e.ProgressPercentage);
        }

        static void WebClientDownloadCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Console.WriteLine("Download finished, Now restarting!");

        }
    }
}