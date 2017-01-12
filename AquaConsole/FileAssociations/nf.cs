using PluginAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.FileAssociations
{
    class nf : IAssociatedFile
    {
        public string Extension
        {
            get
            {
                return "nf";
            }
        }

        public void CommandMethod(string file)
        {
           
        }
    }
}
