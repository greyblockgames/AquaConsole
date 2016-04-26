using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AquaConsole.Commands
{
    class XmlGenerator : ICommand
    {
        public string Command
        {
            get
            {
                return "generatexml";
            }
        }

        public string HelpText
        {
            get
            {
                return null;
            }
        }

        public void CommandMethod(string p)
        {


            XmlWriter xmlWriter = XmlWriter.Create(p + ".xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("plugins");

            while (true)
            {
                string name = Utility.TextInput("Please enter the plugin's name");
                string author = Utility.TextInput("Please enter plugin's auther");
                string description = Utility.TextInput("Please enter plugin's description");
                string url = Utility.TextInput("Please enter direct plugin download url");

                xmlWriter.WriteStartElement("plugin");
                xmlWriter.WriteAttributeString("name", name);
                xmlWriter.WriteAttributeString("author", author);
                xmlWriter.WriteAttributeString("description", description);
                xmlWriter.WriteString(url);
                xmlWriter.WriteEndElement();


                if (!Utility.YesNoStatement("Do you want to add another plugin?"))
                    break;
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Console.WriteLine("file written!");
        }
    }
}
