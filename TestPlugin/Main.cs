using PluginAPI;
using System;

namespace TestPlugin
{
    public class Main : IPlugin
    {
        public string name
        {
            get
            {
                return "TestPlugin";
            }
        }

        public void LoadMethod()
        {
            Console.WriteLine("Test");
        }

        public void PostLoadMethod()
        {            
        }

        public void PreloadMethod()
        {           
        }
    }
}
