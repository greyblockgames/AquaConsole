using PluginAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace AquaConsole.Managers
{
    public class NoticeManager
    {
        
        public static void ReadNotice()
        {
            string noticefile = "notice.nf";
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (Utility.FileOrDirectoryExists(exeDir + "/" + noticefile))
            {
                string line;

                // Read the file and display it line by line.
                StreamReader file =
                   new System.IO.StreamReader(exeDir + "/" + noticefile);
                while ((line = file.ReadLine()) != null)
                {
                    Utility.NotifyWriteLine(line);
                }
                file.Close();
                File.Delete(exeDir + "/" + noticefile);
            }
        }
    }
}