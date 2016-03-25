using AquaConsole;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTool.Commands
{
    class version : ICommand
    {
        public string Command
        {
            get
            {
                return "version";
            }
        }

        public string HelpText
        {
            get
            {
                return "version Display's Console Version";
            }
        }

        public void CommandMethod(string p)
        {
            Console.WriteLine(Program.ProgramVersion);
        }
    }
}
