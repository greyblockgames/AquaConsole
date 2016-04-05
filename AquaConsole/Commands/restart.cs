using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTool.Commands
{
    class restart : ICommand
    {
        public string Command
        {
            get
            {
                return "restart";
            }
        }

        public string HelpText
        {
            get
            {
                return "restarts the application";
            }
        }

        public void CommandMethod(string p)
        {
            Utility.RestartProgram();
        }
    }
}
