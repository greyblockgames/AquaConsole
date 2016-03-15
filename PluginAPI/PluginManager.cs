//https://code.msdn.microsoft.com/windowsdesktop/Creating-a-simple-plugin-b6174b62

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PluginAPI
{
    /// <summary>
    /// This is the interface you will use to register with the console
    /// </summary>
    public interface AquaPlugin
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

    /// <summary>
    /// The class responsible for all things plugins!
    /// </summary>
    public class PluginManager
    {
        /// <summary>
        /// Call this method to load all plugins
        /// </summary>
        /// <param name="pluginFolder"></param>
        public static void loadPlugins(string pluginFolder)
        {
            //Calls DateEvents for date specific events
            DateEvents.Trigger();


            //Search plugin folder
            string[] dllFileNames = null;
            if (Directory.Exists(Environment.CurrentDirectory + "/" + pluginFolder + "/"))
            {
                dllFileNames = Directory.GetFiles(Environment.CurrentDirectory + "/" + pluginFolder + "/", "*.dll");
            }

            //Load assemblies
            if (dllFileNames != null)
            {
                ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
                foreach (string dllFile in dllFileNames)
                {
                    AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                    Assembly assembly = Assembly.Load(an);
                    assemblies.Add(assembly);
                }

                //Load all files
                Type pluginType = typeof(AquaPlugin);
                ICollection<Type> pluginTypes = new List<Type>();
                foreach (Assembly assembly in assemblies)
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();
                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetInterface(pluginType.FullName) != null)
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }

                //create instance of files
                ICollection<AquaPlugin> plugins = new List<AquaPlugin>(pluginTypes.Count);
                foreach (Type type in pluginTypes)
                {
                    AquaPlugin plugin = (AquaPlugin)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }


                var _Plugins = new Dictionary<string, AquaPlugin>();


                foreach (var item in plugins)
                {
                    _Plugins.Add(item.name, item);
                    AquaPlugin plugin = _Plugins[item.name];
                    try { plugin.PreloadMethod(); }
                    catch (NotImplementedException)
                    {

                    }
                    catch (System.ArgumentException e)
                    {
                        Utility.ErrorWriteLine(e.ToString());
                        Console.WriteLine("");
                    }
                }

                foreach (var item in plugins)
                {
                    AquaPlugin plugin = _Plugins[item.name];


                    try { plugin.LoadMethod(); }
                    catch (NotImplementedException)
                    {

                    }
                    catch (System.ArgumentException e)
                    {
                        Utility.ErrorWriteLine(e.ToString());
                        Console.WriteLine("");
                    }
                }

                foreach (var item in plugins)
                {
                    AquaPlugin plugin = _Plugins[item.name];
                    try
                    {
                        plugin.PostLoadMethod();
                    }
                    catch (NotImplementedException)
                    {

                    }
                    catch (System.ArgumentException e)
                    {
                        Utility.ErrorWriteLine(e.ToString());
                        Console.WriteLine("");
                    }
                }                
            }
        }


    }
}