using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginDownloader.Commands
{
    class PluginManager : ICommand
    {
        public string Command
        {
            get
            {
                return "PM";
            }
        }

        public string HelpText
        {
            get
            {
                return "opens the plugin management interface";
            }
        }

        public void CommandMethod(string p)
        {
            xmlLoader.Load(p);
        }
    }
}
