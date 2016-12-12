using AquaConsole;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class quit : ICommand
    {
        public string Command
        {
            get
            {
                return "quit";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.quithelp;
            }
        }

        public void CommandMethod(string[] p)
        {
            Program.quitNow = true;
        }
    }
}