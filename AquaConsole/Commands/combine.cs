using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTool.Commands
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
                return "Injects an archive file into an image";
            }
        }

        public void CommandMethod(string p)
        {
            String image = Utility.TextInput("Please enter the name of the input image (with extension)");
            String zip = Utility.TextInput("Please enter the name of the input archive (with extension)");
            if (Utility.FileOrDirectoryExists(image) && Utility.FileOrDirectoryExists(zip))
            {
                String output = Utility.TextInput("Please enter a name for the output image (with extension)");
                Utility.ExecuteCommandSync("copy / b " + image + " + " + zip + " " + output);
            }
            else
                Utility.ErrorWriteLine("File(s) were not found, please try again...");
        }
    }
}
