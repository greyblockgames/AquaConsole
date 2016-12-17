using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class dir : ICommand
    {
        public string Command
        {
            get
            {
                return "dir";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.dirhelp;
            }
        }

        public void CommandMethod(string[] p)
        {
            Utility.ExecuteCommandSync("dir");
        }
    }
}