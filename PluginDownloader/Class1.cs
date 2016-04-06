using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginDownloader
{
    public class Class1 : ICommand
    {
        public string Command
        {
            get
            {
                return "command manager";
            }
        }

        public string HelpText
        {
            get
            {
                return "HelpText";
            }
        }

        public void CommandMethod(string p)
        {
            Utility.NotifyWriteLine("test");
        }
    }
}
