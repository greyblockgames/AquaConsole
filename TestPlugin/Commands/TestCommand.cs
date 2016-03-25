using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Commands
{
    class TestCommand : ICommand
    {
        public string Command
        {
            get
            {
                return "Hello World";
            }
        }

        public string HelpText
        {
            get
            {
                return "this is a test command from the test plugin";
            }
        }

        public void CommandMethod(string p)
        {
            Utility.NotifyWriteLine("Hello World!");
        }
    }
}
