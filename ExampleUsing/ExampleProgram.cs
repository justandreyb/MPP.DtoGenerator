using DTOGenerator.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.ExampleUsing
{
    class ExampleProgram
    {
        private static String outputDir;
        private static String jsonFilePath;

        static void Main(string[] args)
        {
            /*
            if (args.Length == 2)
            {
                 if ((!Directory.Exists(@args[0])) || (!File.Exists(@args[1])))
                {
                    Console.WriteLine("Invalid path.");
                    Console.ReadKey();
                    return;
                }
                outputDir = args[0];
                jsonFilePath = args[1];
                */
            var maxThreadCount = Int32.Parse(ConfigurationSettings.AppSettings["maxThreadCount"]);
                outputDir = "D://Work/C#/MPP/DTOGenerator/bin/GeneratedClasses/";
                jsonFilePath = "D://Work/C#/MPP/DTOGenerator/bin/JSONFiles/testjson.json";

                DTOGenerator generator = new DTOGenerator(jsonFilePath, maxThreadCount);
               
                generator.generate(outputDir);
                //Console.WriteLine("Generating is complete. Press key.");
                Console.ReadKey();
        /*    }
        
            else
            {
                //throw new Exception();
                Console.WriteLine("Invalid parameters count.");
                Console.ReadKey();
            }
            */
        }
    }
}
