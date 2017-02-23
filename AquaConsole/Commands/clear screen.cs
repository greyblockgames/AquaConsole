using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class clear_screen : ICommand
    {
        public string Command
        {
            get
            {
                return "cls";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.clearhelp;
            }
        }

        public void CommandMethod(string[] p)
        {
            Console.Clear();
        }
    }
}