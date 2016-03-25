using AquaConsole;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTool.Commands
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
                return "exits the program";
            }
        }

        public void CommandMethod(string p)
        {
            Program.quitNow = true;
        }
    }
}
