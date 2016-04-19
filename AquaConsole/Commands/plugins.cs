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
                return "Returns a list of loaded plugins";
            }
        }

        public void CommandMethod(string p)
        {
            foreach (string PluginName in GlobalLists.LoadedPlugins)
            {
                Console.Write(PluginName + ", ");                              
            }
            Console.WriteLine("");
        }
    }
}
