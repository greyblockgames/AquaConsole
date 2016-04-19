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

        public void CommandMethod(string p)
        {
            if (Utility.FileOrDirectoryExists(p))
                Environment.CurrentDirectory = p;
            else
                Utility.ErrorWriteLine(strings.cderrorpathnotfound);
        }
    }
}