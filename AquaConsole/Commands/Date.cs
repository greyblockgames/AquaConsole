using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class Date : ICommand
    {
        public string Command
        {
            get
            {
                return "date";
            }
        }

        public string HelpText
        {
            get
            {
                return "Displayes the current date.";
            }
        }

        public void CommandMethod(string p)
        {            
            DateTime today = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            Console.WriteLine(today.ToShortDateString());
        }
    }
}
