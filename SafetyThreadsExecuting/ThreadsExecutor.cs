using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOGenerator.SafetyThreadsExecuting
{
    class ThreadsExecutor : ISafety
    {
        private static Object threadLock = new Object();

        //thread-safe execute container from list
        public virtual T ThreadSafeExecute<T>(LinkedList<T> classes, ref int index)
        {
            lock (threadLock)
            {
                Object currentClass = new Object();
                currentClass = classes.ElementAt(index);
                index++;
                return (T)currentClass;
            }
        }

    }
}
