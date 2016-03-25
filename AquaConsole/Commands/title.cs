using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTool.Commands
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
                return "Sets the console title";
            }
        }

        public void CommandMethod(string p)
        {
            Console.Title = p;
        }
    }
}
