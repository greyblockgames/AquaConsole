using System;
using System.Linq;
using PluginAPI;

namespace AquaConsole
{

    class Program
    {
        public static Boolean quitNow = false;

        public static string ProgramVersion = "AquaDark Console [Version 1.1.0100]";

        static void Main(string[] args)
        {
            Setup();
            String RootCommand;
            String command;
            String Argument;


            while (!quitNow)
            {
                Console.WriteLine("");
                Console.Write(Environment.CurrentDirectory + ">");
                RootCommand = Console.ReadLine();
                command = RootCommand.Split(' ').First();
                Argument = RootCommand.Remove(command.IndexOf(command), command.Length);




                CommandManager.RunCommand(command, Argument);


            }
        }

        private static void Setup()
        {
            RegisterCommands();
            PluginAPI.PluginManager.loadPlugins("plugins");
            PluginAPI.CommandManager.LoadCommands(ICommand);
            Environment.CurrentDirectory = "C:/";
            if (!Utility.IsUserAdministrator())
                Utility.ErrorWriteLine("Warning, Admin priveleges not detected, not all commands will work!");
            Console.Title = "AquaDark Console";
            Console.WriteLine(ProgramVersion);
            Console.WriteLine("<c> 2016 AquaDark Corporation. All rights reserved.");

            CommandManager.HelpText.Sort();
        }

        private static void RegisterCommands()
        {
            CommandManager.CommandDictionary.Add("help", (p) => { Commands.Help(p); });
            CommandManager.HelpText.Add("help Displays this help text");

            CommandManager.CommandDictionary.Add("version", (p) => { Commands.Version(); });
            CommandManager.HelpText.Add("version Display's Console Version");

            CommandManager.CommandDictionary.Add("cls", (p) => { Commands.Clear(); });
            CommandManager.HelpText.Add("cls Clears the console");

            CommandManager.CommandDictionary.Add("title", (p) => { Commands.Title(p); });
            CommandManager.HelpText.Add("title Sets the console title");

            CommandManager.CommandDictionary.Add("cap", (p) => { Commands.Cap(); });
            CommandManager.HelpText.Add("cap Changes account password if you have admin rights");

            CommandManager.CommandDictionary.Add("cd", (p) => { Commands.cd(p); });
            CommandManager.HelpText.Add("cd Changes current selected directory");

            CommandManager.CommandDictionary.Add("combine", (p) => { Commands.HideZipInImage(); });
            CommandManager.HelpText.Add("combine Injects an archive file into an image");

            CommandManager.CommandDictionary.Add("dir", (p) => { Commands.dir(); });
            CommandManager.HelpText.Add("dir Displays a list of files and subdirectories in a directory.");

            CommandManager.CommandDictionary.Add("cmd", (p) => { Commands.cmd(p); });
            CommandManager.HelpText.Add("cmd Executes a command prompt command");

            CommandManager.CommandDictionary.Add("quit", (p) => { quitNow = true; });
            CommandManager.HelpText.Add("quit exits the program");
        }



    }
}
