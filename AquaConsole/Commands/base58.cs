using PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class base58 : ICommand
    {
        public string Command
        {
            get
            {
                return "tobase58";
            }
        }

        public string HelpText
        {
            get
            {
                return "encodes the supplied string as base 58";
            }
        }

        public void CommandMethod(string p)
        {

        }

            string base58_encode(int num, string vers)
  {
    string alphabet[58] = {"1","2","3","4","5","6","7","8","9","A","B","C","D","E","F",
    "G","H","J","K","L","M","N","P","Q","R","S","T","U","V","W","X","Y","Z","a","b","c",
    "d","e","f","g","h","i","j","k","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
    int base_count = 58; string encoded; Integer div; Integer mod;
    while (num >= base_count)
    {
        div = num / base_count; mod = (num - (base_count * div));
        encoded = alphabet[mod.ConvertToLong()] + encoded; num = div;
    }
    encoded = vers + alphabet[num.ConvertToLong()] + encoded;
    return encoded;
}
    
    
