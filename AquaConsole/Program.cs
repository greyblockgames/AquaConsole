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

        //Program version string
        public static string ProgramVersion
        {
            get
            {
                return "AquaConsole [" + strings.version + " " + GetVersion() + "]";
            }
        } 

        static string GetVersion()
        {
            if (Assembly.GetExecutingAssembly().GetName().Version.ToString().Equals("1.0.0.0"))
            {
                return "UNKNOWN";
            }
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }



        //Entry method
        static void Main(string[] args)
        {
            var CommandManager = new CommandManager();
            Setup();

           
            //Runs file that was opened with AC.
            if (args.Length > 0)
            {              
                AFManager.OpenAssociatedFile(args[0]);
            }

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



        //Where everything gets set up :)
        internal static void Setup()
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!Utility.FileOrDirectoryExists(@exeDir + @"\plugins\"))
            {
                Directory.CreateDirectory(@exeDir + @"\plugins\");
                Console.WriteLine("created plugins folder");
            }

            //Loading sequence
            PluginManager PluginManager = new PluginManager();
            PluginManager.loadPlugins("plugins");
            Console.WriteLine("loaded plugins...");
            AFManager.LoadAssociations();
            Console.WriteLine("Set file associations...");
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