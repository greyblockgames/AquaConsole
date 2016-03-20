using PluginAPI;
using System;
using System.Linq;

namespace AquaConsole
{
    class Commands
    {
        public static void Help(string RequestedCommand)
        {
                    var offset = CommandManager.HelpText.Max(s => s.Length / 2);
                    var formatString = "{0,-" + offset + "}     {1}";
                    Console.WriteLine(formatString, "=======", " =====");
                    Console.WriteLine(formatString, "Command", " Usage");
                    Console.WriteLine(formatString, "=======", " =====");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    foreach (string helptext in CommandManager.HelpText)
                    {
                        string command = helptext.Split(' ').First();
                        string help = helptext.Remove(command.IndexOf(command), command.Length);
                        Console.WriteLine(formatString, command, help);
                    }
                    Console.ResetColor();                    
            }        

        public static void Version()
        {
            Console.WriteLine(Program.ProgramVersion);
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void Title(string title)
        {
            Console.Title = title;
        }

        public static void Cap()
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


        public static void cd(string path)
        {
            if (Utility.FileOrDirectoryExists(path))
                Environment.CurrentDirectory = path;
            else
                Utility.ErrorWriteLine("File Path Not Found");
        }

        public static void HideZipInImage()
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

        public static void dir()
        {
            Utility.ExecuteCommandSync("dir");
        }


        public static void cmd(string command)
        {
            if (!string.IsNullOrEmpty(command))
                Utility.ExecuteCommandSync(command);
            else
                Utility.ErrorWriteLine("Error: no argument's were supplied.");
        }

    }
}