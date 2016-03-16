using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PluginAPI
{
    class DateEvents
    {
        public static void Trigger()
        {
            DateTime LukasBirthday = new DateTime(DateTime.Today.Year, 3, 29);

            if (LukasBirthday == DateTime.Today)
            {
                Console.Title = "Happy birthday LUKAS";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Happy ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Birthday ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Lukas!!!");
                Console.ResetColor();

                HappyBirthdaySong();


                System.Threading.Thread.Sleep(100);
                Console.Clear();
            }
        }

        private static void HappyBirthdaySong()
        {
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
        }

    }
}
