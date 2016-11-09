using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DTOGenerator.DTO;
using DTOGenerator.JSON;
using System.IO;
using DTOGenerator.JSON.Creator;

namespace DTOGenerator
{
    class JSONObjectCreator
    {
        private LinkedList<Class> classes = new LinkedList<Class>();

        public void create(string outputPath)
        {
            ClassCreator creator = new ClassCreator();
            for (int i = 0; i < 5; i++)
            {
                classes.AddLast(creator.create());
            }
            string json = JsonConvert.SerializeObject(classes);
            write(outputPath, json);
        }

        public void create(LinkedList<Class> classes, string outputPath)
        {
            string json = JsonConvert.SerializeObject(classes);
            write(outputPath, json);
        }

        private void write(String outputPath, String json)
        {
            if (outputPath.ElementAt(outputPath.Length - 1) == '/')
            {
                File.WriteAllText(outputPath + RandomName.getRandomName() + ".json", json);
            }
            else
            {
                File.WriteAllText(outputPath + "/" + RandomName.getRandomName() + ".json", json);
            }
        }
    }
}
