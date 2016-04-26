using System;
using System.Linq;
using PluginAPI;
using System.IO;

using AquaConsole.Managers;
using System.Reflection;

namespace AquaConsole
{

    class Program
    {
        public static Boolean quitNow = false;

        public static string ProgramVersion = "AquaConsole [" + strings.version +" "+ "1.4.0000]";

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
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);            
            if (!Utility.FileOrDirectoryExists(@exeDir + @"\plugins\"))
            {
                Directory.CreateDirectory(@exeDir + @"\plugins\");
                Console.WriteLine("created plugins folder");
            }


            
            PluginManager.loadPlugins("plugins");
            Console.WriteLine("loaded plugins...");
            CommandManager.LoadCommands();
            Console.WriteLine("loaded commands...");
            Environment.CurrentDirectory = "C:/";
            Console.WriteLine("set current directory to C:/");
            Console.Clear();

            NoticeManager.ReadNotice();







            if (!Utility.IsUserAdministrator())
                Utility.ErrorWriteLine(strings.warningnotadmin);

            Console.Title = "AquaConsole";
            Console.WriteLine(ProgramVersion);
            Console.WriteLine(strings.copyrightGBG);

            CommandManager.HelpText.Sort();
        }





    }
}
