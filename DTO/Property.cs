using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.DTO
{
    class Property
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String type;
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        private String format;
        public String Format
        {
            get { return format; }
            set { format = value; }
        }
    }

}
