using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOGenerator.JSON;
using System.IO;
using DTOGenerator.DTO;
using System.Threading;
using DTOGenerator.SafetyThreadsExecuting;

namespace DTOGenerator
{
    class DTOGenerator : IDTOGenerator
    {
        private DTOContainer container;
        private readonly object lockObject = new object();
        private int index;

        private int maxThreadsCount;
        SemaphoreSlim semaphore;

        public DTOGenerator(String jsonFilePath, int maxThreadsCount)
        {
            /*
            String jsonFilePath;
            if ((!Directory.Exists(@args[0])) || (!File.Exists(@args[1])))
            {
                Console.WriteLine("Invalid path. Please enter correct path for json file");
                jsonFilePath = Console.ReadLine();
            } else
            {
                jsonFilePath = args[1];
                outputDir = args[0];
            }
            */
            this.maxThreadsCount = maxThreadsCount;
            this.semaphore = new SemaphoreSlim(maxThreadsCount, maxThreadsCount);
            this.index = 0;

            JSONParser parser = new JSONParser();
            try
            {
                container = parser.parse(jsonFilePath); 
            } catch
            {
                Console.WriteLine("Error with parsing json file");
                throw new Exception();
            }
       }

        public void generate(String outputDir)
        {
            var finished = new CountdownEvent(1); // Used to wait for the completion of all work items.
            for (int i = 0; i < container.getClasses().Count; i++)
            {
                finished.AddCount();
                semaphore.Wait();
                ThreadPool.QueueUserWorkItem(
                    (state) => {
                        try
                        {
                            createClass(outputDir);
                        }
                        finally
                        {
                            semaphore.Release();
                            finished.Signal();
                        }
                    }
                    , null);
            }
            finished.Signal();
            finished.Wait();
        }

        private void createClass(String outputDir)
        {
            lock (lockObject)
            {
                ThreadsExecutor executor = new ThreadsExecutor();
                Class currentClass = executor.ThreadSafeExecute(container.getClasses(), ref index);
                createCSFile(outputDir, currentClass);
            }
        }
        private void createCSFile(String outputDir, Class currentClass)
        { 
                var outputFileName = "";
                if (!outputDir.Equals(""))
                {
                    outputFileName = outputDir + currentClass.ClassName + ".cs";
                } else
                {
                    outputFileName = currentClass.ClassName + ".cs";
                }

                Console.WriteLine("\"{0}\"", outputFileName);
                //T4 var generatedCode = generateClassCode(currentClass);
                //T4 File.WriteAllText(outputFileName, generatedCode);
        }
    }
}
