using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTool.Commands
{
    class dir : ICommand
    {
        public string Command
        {
            get
            {
                return "dir";
            }
        }

        public string HelpText
        {
            get
            {
                return "Displays a list of files and subdirectories in a directory.";
            }
        }

        public void CommandMethod(string p)
        {
            Utility.ExecuteCommandSync("dir");
        }
    }
}
