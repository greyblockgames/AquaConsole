using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class combine : ICommand
    {
        public string Command
        {
            get
            {
                return "combine";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.combinehelp;
            }
        }

        public void CommandMethod(string p)
        {
            String image = Utility.TextInput(strings.combineiimage);
            String zip = Utility.TextInput(strings.combineiarchive);
            if (Utility.FileOrDirectoryExists(image) && Utility.FileOrDirectoryExists(zip))
            {
                String output = Utility.TextInput(strings.combineoimage);
                Utility.ExecuteCommandSync("copy / b " + image + " + " + zip + " " + output);
            }
            else
                Utility.ErrorWriteLine(strings.fileswerenotfound);
        }
    }
}