using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginAPI
{
    /// <summary>
    /// Use this interface for all your commands
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// return the command name string
        /// </summary>
        string Command
        {
            get;
        }

        /// <summary>
        /// Return the text that will be displayed in the help menu
        /// </summary>
        string HelpText
        {
            get;
        }


        /// <summary>
        /// Your commands method, P is the parametre supplied.
        /// </summary>
        /// <param name="p"></param>
        void CommandMethod(string p);

    }


    /// <summary>
    /// This is the interface you will use to register with the console
    /// </summary>
    public interface IPlugin
    {

        /// <summary>
        /// return your plugin name here
        /// </summary>
        string name
        {
            get;
        }

        /// <summary>
        /// Preload method, Anything that should be executed first on plugin load, should go here.
        /// </summary>
        void PreloadMethod();

        /// <summary>
        /// Main loading method, Most things should go here.
        /// </summary>
        void LoadMethod();

        /// <summary>
        /// Postload method, Anything that should be executed last on plugin load, should go here.
        /// </summary>
        void PostLoadMethod();
    }
}
