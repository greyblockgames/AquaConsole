using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class cd : ICommand
    {
        public string Command
        {
            get
            {
                return "cd";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.cdhelp;
            }
        }

        public void CommandMethod(string[] p)
        {
            string path = string.Empty;
            for (int i = 0; i < p.Length; i++)
            {               
                path = path + " " + p[i];
            }
                path = path.Replace(@"""", "");
            if (Utility.FileOrDirectoryExists(path))
                Environment.CurrentDirectory = path;
            else
                Utility.ErrorWriteLine(strings.cderrorpathnotfound);           
        }
    }
}