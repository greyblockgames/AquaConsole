using AquaConsole;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
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
                return strings.versionhelp;
            }
        }

        public void CommandMethod(string p)
        {
            Console.WriteLine(Program.ProgramVersion);
        }
    }
}
