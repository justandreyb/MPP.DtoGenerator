using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace DTOGenerator.DTO
{
    class Class
    {
        private String className;
        public String ClassName
        {
            get { return className; }
            set { className = value; }
        }

        private List<Property> propertyList = new List<Property>();
        public List<Property> PropertyList
        {
            get { return propertyList; }
            set { propertyList = value; }
        }

        public void addProperty(Property property)
        {
            this.propertyList.Add(property);
        }
    }
}
