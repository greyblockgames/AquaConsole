using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class title : ICommand
    {
        public string Command
        {
            get
            {
                return "title";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.titlehelp;
            }
        }

        public void CommandMethod(string p)
        {
            Console.Title = p;
        }
    }
}