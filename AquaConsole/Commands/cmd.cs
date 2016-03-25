using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTool.Commands
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
                return "Executes a command prompt command";
            }
        }

        public void CommandMethod(string p)
        {
            if (!string.IsNullOrEmpty(p))
                Utility.ExecuteCommandSync(p);
            else
                Utility.ErrorWriteLine("Error: no argument's were supplied.");
        }
    }
}
