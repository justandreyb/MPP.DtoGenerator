using DTOGenerator.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.JSON
{
    class JSONParser
    {
        public DTOContainer parse(String jsonPath)
        {
            DTOContainer container = new DTOContainer();
            LinkedList<Class> currentClasses = null;
            string json = System.IO.File.ReadAllText(jsonPath);
            try
            {
                currentClasses = JsonConvert.DeserializeObject<LinkedList<Class>>(json);
            }
            catch
            {
                Console.WriteLine("Error in JSON file. Please, check \"{0}\"", jsonPath);
            }
            if (currentClasses != null) { container.addClasses(currentClasses); }

            return container;
        } 
    }
}
