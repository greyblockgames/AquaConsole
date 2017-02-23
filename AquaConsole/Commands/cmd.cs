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

        public void CommandMethod(string[] p)
        {
            string path = string.Empty;
            for (int i = 0; i < p.Length; i++)
            {
                path = path + p[i];
            }

            if (!string.IsNullOrWhiteSpace(path))
                Utility.ExecuteCommandSync(path);
            else
                Utility.ErrorWriteLine(strings.errornoargumentssupplied);
        }
    }
}