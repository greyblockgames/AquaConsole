﻿using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole
{
    class CommandManager
    {
        public static List<string> HelpText = new List<string>();
        private static Dictionary<String, Action<string>> CommandDictionary = new Dictionary<String, Action<string>>();

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