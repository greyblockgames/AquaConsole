using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class cmd : ICommand
    {
        public string Command
        {
            get
            {
                return "cmd";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.cmdhelp;
            }
        }

        public void CommandMethod(string p)
        {
            if (!string.IsNullOrWhiteSpace(p))
                Utility.ExecuteCommandSync(p);
            else
                Utility.ErrorWriteLine(strings.errornoargumentssupplied);
        }
    }
}