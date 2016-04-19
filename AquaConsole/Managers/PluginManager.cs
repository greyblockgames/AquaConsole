
using AquaConsole.Managers;
using PluginAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace AquaConsole.Managers
{
    class PluginManager
    {

        public static ICollection<Type> commandTypes = new List<Type>();

        public static void loadPlugins(string pluginFolder)
        {

            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Calls DateEvents for date specific events
            DateEvents.Trigger();


            //Search plugin folder
            string[] dllFileNames = null;
            if (Directory.Exists(exeDir + "/" + pluginFolder + "/"))
            {
                dllFileNames = Directory.GetFiles(exeDir + "/" + pluginFolder + "/", "*.dll");
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
                Type pluginType = typeof(IPlugin);
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
                                else
                                {
                                    if (type.GetInterface(typeof(ICommand).FullName) != null)
                                    {
                                        commandTypes.Add(type);
                                    }
                                }
                            }
                        }
                    }
                }

                //create instance of files
                ICollection<IPlugin> plugins = new List<IPlugin>(pluginTypes.Count);
                foreach (Type type in pluginTypes)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }




                var _Plugins = new Dictionary<string, IPlugin>();


                foreach (var item in plugins)
                {
                    _Plugins.Add(item.name, item);
                    IPlugin plugin = _Plugins[item.name];
                    GlobalLists.LoadedPlugins.Add(item.name);

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
                    IPlugin plugin = _Plugins[item.name];


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
                    IPlugin plugin = _Plugins[item.name];
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