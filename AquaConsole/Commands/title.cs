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

        public void CommandMethod(string[] p)
        {
            string path = string.Empty;
            for (int i = 0; i < p.Length; i++)
            {
                path = path + " " + p[i];
            }
            Console.Title = path;
        }
    }
}