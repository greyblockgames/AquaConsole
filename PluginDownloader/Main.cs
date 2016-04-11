using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginDownloader
{
    public class Main : IPlugin
    {
        public string name
        {
            get
            {
                return "Plugin Manager";
            }
        }

        public void LoadMethod()
        {
            throw new NotImplementedException();
        }

        public void PostLoadMethod()
        {
            throw new NotImplementedException();
        }

        public void PreloadMethod()
        {
            throw new NotImplementedException();
        }
    }
}
