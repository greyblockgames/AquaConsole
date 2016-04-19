using AquaConsole.Managers;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class help : ICommand
    {
        public string Command
        {
            get
            {
                return "help";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.helphelp;
            }
        }

        public void CommandMethod(string p)
        {

            


            var offset = CommandManager.HelpText.Max(s => s.Length / 2);
            var formatString = "{0,-" + offset + "}     {1}";
            Console.WriteLine(formatString, strings.helpmenucommandborder, " " + strings.helpmenuusageborder);
            Console.WriteLine(formatString, strings.helpmenucommand, " " + strings.helpmenuusage);
            Console.WriteLine(formatString, strings.helpmenucommandborder, " " + strings.helpmenuusageborder);

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string helptext in CommandManager.HelpText)
            {
                string command = helptext.Split(' ').First();
                string help = helptext.Remove(command.IndexOf(command), command.Length);
                Console.WriteLine(formatString, command, help);
            }
            Console.ResetColor();
        }
    }
}