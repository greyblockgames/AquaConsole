using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        void CommandMethod(string p);
    }





    public class CommandManager
    {

        readonly static Dictionary<String, Action<string>> CommandDictionary = new Dictionary<String, Action<string>>();
        readonly static List<string> HelpText = new List<string>();

        public static void LoadCommands()
        {
            foreach (Type t in Assembly.GetCallingAssembly().GetTypes())
            {
                if (t.GetInterface("ICommand") != null)
                {
                    ICommand executor = Activator.CreateInstance(t) as ICommand;


                    HelpText.Add(executor.Command.ToLower() + " " + executor.HelpText.ToLower());
                    CommandDictionary.Add(executor.Command.ToLower(), (p) => { executor.CommandMethod(p); });
                }
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
            if (CommandDictionary.ContainsKey(commandname.ToLower()))
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
