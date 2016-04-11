using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PluginDownloader
{
    class xmlLoader
    {
        public static void Load(string p)
        {
            

            List<string> PluginName = new List<string>();
            List<string> PluginAuthor = new List<string>();
            List<string> PluginDescription = new List<string>();
            List<string> PluginURL = new List<string>();
            List<string> PluginHelpText = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(p + ".xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                //Loops through xml file and adds attributes to list's
                PluginName.Add(node.Attributes["name"]?.InnerText);
                PluginAuthor.Add(node.Attributes["author"]?.InnerText);
                PluginDescription.Add(node.Attributes["description"]?.InnerText);
                PluginURL.Add(node.InnerText);
            }

            //Creates list for interface
            foreach (string name in PluginName)
            {
                PluginHelpText.Add(PluginName + " " + PluginDescription + " " + PluginAuthor);
            }

            //Sorts list
            PluginHelpText.Sort();

            Console.Clear();            



            //Full Screen
            Console.BufferWidth = Console.LargestWindowWidth;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;

            var consoleWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;           
            Imports.SetWindowPos(consoleWnd, 0, 0, 0, 0, 0, Imports.SWP_NOSIZE | Imports.SWP_NOZORDER);

            //Begins creating menu
            var offset = PluginHelpText.Max(s => s.Length / 2);
            var formatString = "{0,-" + offset + "}     {1,-" + offset + "}    {2}";
          


            Console.WriteLine(formatString, "=====",  "===========", "======");
            Console.WriteLine(formatString, "Name ",  "Description", "Author");
            Console.WriteLine(formatString, "=====",  "===========", "======");


            int counter = 0;
            foreach (string name in PluginName)
            {
                counter++;             
                Console.WriteLine(formatString, counter.ToString() + ") " + PluginName[counter - 1], PluginDescription[counter - 1], PluginAuthor[counter - 1]);
            }


            //Takes Input
            Console.Write("Please Make A Selection: ");
            string input = Console.ReadLine();
            int number = 9;
            int.TryParse(input, out number);

            if (number <= PluginName.Count)
                Console.WriteLine("Great success!!!" + number.ToString());
            else
                Console.WriteLine(":(" + number.ToString());


            }
    }
}