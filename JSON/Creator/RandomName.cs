using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.JSON.Creator
{
    class RandomName
    {

        private static Random rand = new Random(DateTime.UtcNow.Second);

        public static String getRandomType()
        {
            string[] names = new string[] { "integer", "number", "string", "boolean" };
            return names[rand.Next(0, names.Length - 1)];
        }

        public static String getRandomFormat(String type)
        {
            string[] names;
            switch (type)
            {
                case "integer":
                    names = new string[] { "int32", "int64" };
                    break;
                case "number":
                    names = new string[] { "float", "double" };
                    break;
                case "string":
                    names = new string[] { "byte", "date", "string" };
                    break;
                case "boolean":
                    return "bool";
                default:
                    return "Object";
            }
            return names[rand.Next(0, names.Length - 1)];
        }

        public static String getRandomName()
        {
            string[] names = new string[] { "Aaron", "Gertie", "Chester", "Rosalva", "Alysa", "Danika",
                "Jerrie", "Val", "Iliana", "Carroll", "Vernice", "Ethelyn", "Kali", "Hsiu", "Jonas",
                "Juliet", "Gabriel", "Roxanne", "Donn", "Vada", "Tresa", "Katherina", "Hollis",
                "Adele", "Adrian" };
            return names[rand.Next(0, names.Length - 1)];

        }
    }
}
