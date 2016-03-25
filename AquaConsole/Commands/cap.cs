using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class cap : ICommand
    {
        public string Command
        {
            get
            {
                return "cap";
            }
        }

        public string HelpText
        {
            get
            {
                return "Changes account password if you have admin rights";
            }
        }

        public void CommandMethod(string p)
        {
            if (Utility.IsUserAdministrator())
            {
                if (Utility.YesNoStatement("Do you want to change an accounts password?"))
                {
                    Utility.ExecuteCommandSync("net user " + Utility.TextInput("Enter Username") + " " + Utility.TextInput2("Enter Desired password"));
                    Console.WriteLine("Changed Password");
                }
            }
            else
                Utility.ErrorWriteLine("Admin privileges not present, cannot change password.");

            if (Utility.YesNoStatement("Do you want to view current user accounts?") == true)
                Utility.ExecuteCommandSync("net user");
        }
    }
}
