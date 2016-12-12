using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class fullscreen : ICommand
    {
        public string Command
        {
            get
            {
                return "fs";
            }
        }

        public string HelpText
        {
            get
            {
                return strings.fullscreentext;
            }
        }

        public void CommandMethod(string[] p)
        {
            Console.BufferWidth = Console.LargestWindowWidth;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);
        }
    }
}
