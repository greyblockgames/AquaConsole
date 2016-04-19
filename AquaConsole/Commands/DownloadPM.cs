using PluginAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



//WIP
namespace AquaConsole.Commands
{
    class DownloadPM : ICommand
    {
        public string Command
        {
            get
            {
                return null;
                //if (!GlobalLists.LoadedPlugins.Contains("Plugin Manager"))
                //    return "dpm";
                //else
                //    return null;
            }
        }

        public string HelpText
        {
            get
            {
                if (!GlobalLists.LoadedPlugins.Contains("Plugin Manager"))
                    return "downloads the official plugin management plugin";
                else
                    return null;
            }
        }

        public void CommandMethod(string p)
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Console.WriteLine(@exeDir + @"\plugins\" + "PluginDownloader" + ".dll");

            try
            {
                
                

                WebClient client = new WebClient();
                Uri ur = new Uri("https://dl.dropboxusercontent.com/u/81022000/PluginDownloader.dll");


                client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                client.DownloadDataCompleted += WebClientDownloadCompleted;
                client.DownloadFileAsync(ur, @exeDir + @"\plugins\" + "PluginDownloader" + ".dll");




                //Makes a notice
                Utility.WriteNotice("The Plugin Manager has been installed successfully!");

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
