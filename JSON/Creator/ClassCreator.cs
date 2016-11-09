using DTOGenerator.DTO;
using DTOGenerator.JSON.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.JSON
{
    class ClassCreator
    {

        public Class create()
        {
            String className = RandomName.getRandomName();
            List<Property> properties = new List<Property>();
            for (int i = 0; i < 4; i++)
            {
                properties.Add(createRandomProperty());
            }

            return createClass(className, properties);
        }
        
        private Class createClass(String className, List<Property> fields)
        {
            Class temp = new Class();
            temp.ClassName = className;
            temp.PropertyList = fields;
            return temp;
        }

        private Property createProperty(String fieldName, String typeName, String format)
        {
            Property temp = new Property();
            temp.Name = fieldName;
            temp.Type = typeName;
            temp.Format = format;
            return temp;
        }
        private Property createRandomProperty()
        {
            String propertyName = RandomName.getRandomName();
            String propertyType = RandomName.getRandomType();
            String propertyFormat = RandomName.getRandomFormat(propertyType);

            return createProperty(propertyName, propertyType, propertyFormat);
        }

    }
}
