using DTOGenerator.DTO;
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
            Class currentClass = new Class();
            

            return currentClass;
        }
        
        //create here new classes
        private Class createClass(String className, LinkedList<Property> fields)
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
        private void addField(Class currentClass, Property property)
        {
            currentClass.addProperty(property);
        }
    }
}
