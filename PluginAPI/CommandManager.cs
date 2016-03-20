using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI
{

    /// <summary>
    /// The class responsible for registering and processing commands
    /// </summary>
    public class CommandManager
    {
        //Creates a dictionary for all the commands

        /// <summary>
        /// Register your commands to this dictionary, Example: CommandManager.CommandDictionary.Add("help", (p) => { /* use p to compute something*/ });
        /// </summary>
        public static Dictionary<String, Action<string>> CommandDictionary = new Dictionary<String, Action<string>>();

        /// <summary>
        /// Register your help text to this dictionary, Example: CommandManager.HelpText.Add("help Displays this help text");
        /// </summary>
        public static List<string> HelpText = new List<string>();


        

        /// <summary>
        /// Runs the specified command
        /// </summary>
        /// <param name="commandname"></param>
        /// <param name="parameter"></param>
        public static void RunCommand(string commandname, string parameter)
        {
            //Checks if the dictionary contains the command, otherwise output unknown command error
            if (CommandDictionary.ContainsKey(commandname))
            {
                CommandDictionary[commandname](parameter);
            }
            else
            {
                Utility.ErrorWriteLine("Unknown command " + commandname);
            }
        }

        /// <summary>
        /// Generates and/or returns the help menu.
        /// </summary>
        public static void GenerateHelpMenu()
        {

            foreach (string helptext in CommandManager.HelpText)
            {
                
            }

        }
    }
}
