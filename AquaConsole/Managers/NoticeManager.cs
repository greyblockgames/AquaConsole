using PluginAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AquaConsole.Managers
{
    public static class NoticeManager
    {
        private static string noticefile = "notice.txt";
        public static void ReadNotice()
        {
            if (Utility.FileOrDirectoryExists(noticefile))
            {
                string line;

                // Read the file and display it line by line.
                StreamReader file =
                   new System.IO.StreamReader(noticefile);
                while ((line = file.ReadLine()) != null)
                {
                    Utility.NotifyWriteLine(line);
                }

                file.Close();

                File.Delete(noticefile);
            }
        }
    }
}