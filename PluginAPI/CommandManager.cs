using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI
{

    public interface ICommand
    {
        string Command
        {
            get;
        }

        string HelpText
        {
            get;
        }

        void CommandMethod();
    }




    
    public class CommandManager
    {
        
        public static Dictionary<String, Action<string>> CommandDictionary = new Dictionary<String, Action<string>>();        
        public static List<string> HelpText = new List<string>();

        public static void LoadCommands()
        {
            foreach (ICommand item in ICommand)
            {
                Console.WriteLine(item);
            }
        }


        

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

       
    }
}
