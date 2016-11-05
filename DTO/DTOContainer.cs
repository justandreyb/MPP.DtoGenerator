using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.DTO
{
    class DTOContainer
    {
        private LinkedList<Class> programClasses;

        public void addClass(String className, LinkedList<Property> fields)
        {
            Class currentClass = new Class();
            currentClass.ClassName = className;
            currentClass.PropertyList = fields;
            programClasses.AddLast(currentClass);
        }
        public void addClasses(LinkedList<Class> classes)
        {
            this.programClasses = classes;
        }

        public LinkedList<Class> getClasses()
        {
            LinkedList<Class> temp = programClasses;
            return temp;
        }
    }
}
