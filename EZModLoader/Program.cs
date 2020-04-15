using System;
using System.IO;
using System.Reflection;

namespace EZModLoader
{
    class Program
    {

        private static string logPath = "EZModLoaderLog.txt";
        /// <summary>
        /// Invoked by Doorstop
        /// </summary>
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter(logPath, false))
            {
                try
                {
                    writer.WriteLine("Starting modload");
                    var targetDir = "Endzone_Data" + Path.DirectorySeparatorChar + "Managed";

                    // We don't have to ignore ourselves because we're not in the Preloader class
                    foreach (string filepath in Directory.GetFiles(targetDir, "*.dll"))
                    {
                        try
                        {
                            var dll = Assembly.LoadFile(filepath);

                            foreach (Type t in dll.ExportedTypes)
                            {
                                if (t.Name == "Preloader")
                                {
                                    foreach (var m in t.GetRuntimeMethods())
                                    {
                                        if (m.Name == "Main")
                                        {
                                            writer.WriteLine("Loading mod... " + filepath);
                                            try
                                            {
                                                object result = m.Invoke(null, null);
                                                writer.WriteLine("Finished with result " + result);
                                            }
                                            catch (Exception e)
                                            {
                                                writer.WriteLine(e.StackTrace);
                                                writer.WriteLine("Exception: " + e.Message);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            writer.WriteLine(e.StackTrace);
                            writer.WriteLine("Exception: " + e.Message);
                            writer.WriteLine("Unable to load file");
                        }
                    }
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.StackTrace);
                    writer.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    writer.WriteLine("Load finished, exiting");
                    writer.Dispose();
                }
            }
        }
    }
}
