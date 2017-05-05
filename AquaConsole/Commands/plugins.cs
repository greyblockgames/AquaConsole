using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class plugins : ICommand
    {
        public string Command
        {
            get
            {
                return "plugins";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.pluginshelp;
            }
        }

        public void CommandMethod(string[] p)
        {
            Console.Write("Plugins(" + GlobalLists.LoadedPlugins.Count + "): ");
            foreach (string PluginName in GlobalLists.LoadedPlugins)
            {               
                Console.Write(PluginName + ", ");                              
            }
            Console.WriteLine("");
        }
    }
}