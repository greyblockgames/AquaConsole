using AquaConsole.Managers;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaConsole.Commands
{
    class EncryptFile : ICommand
    {
        public string Command
        {
            get
            {
                return "encryption";
            }
        }

        public string HelpText
        {
            get
            {
                return "Encrypts or decrypts a file using a supplied password";
            }
        }

        public void CommandMethod(string p)
        {
            var Encrypt = new Encryption();

            if (p.Equals("encrypt"))
            {
                string input = Utility.TextInput("File to be encrypted (including extension):");
                if (Utility.FileOrDirectoryExists(input))
                {
                    Console.WriteLine("Password:");
                    Encrypt.Phrase = Utility.ReadLineMasked(Char.Parse("*"));
                    Encrypt.Encrypt(input, "Encrypted" + Path.GetExtension(input));                    
                    Utility.NotifyWriteLine("Complete!");
                }
                else
                {
                    Utility.ErrorWriteLine(strings.fileswerenotfound);
                }

            }
            else if (p.Equals("decrypt"))
            {
                string input = Utility.TextInput("File to be decrypted (including extension):");
                if (Utility.FileOrDirectoryExists(input))
                {
                    string output = "Output -" + input;
                    Console.WriteLine("Password:");
                    Encrypt.Phrase = Utility.ReadLineMasked(Char.Parse("*"));
                    Encrypt.Decrypt(input, "Decrypted" + Path.GetExtension(input));                    
                    Utility.NotifyWriteLine("Complete!");
              
                }
                else
                {
                    Utility.ErrorWriteLine(strings.fileswerenotfound);
                }
            }
            else
            {
                Utility.NotifyWriteLine("Correct Usage: encrypt {parameter}");
                Utility.NotifyWriteLine("Valid Parameters:");
                Utility.NotifyWriteLine("encrypt - encrypts a file");
                Utility.NotifyWriteLine("decrypt - decrypts a file");
            }






        }
    }
}
