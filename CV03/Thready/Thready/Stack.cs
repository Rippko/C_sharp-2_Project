using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thready
{
    class SimpleStack<T>
    {

        private List<T> data = new List<T>();

        public T Top
        {
            get
            {
                lock (data)
                {
                    int idx = this.data.Count - 1;
                    if (idx == -1)
                    {
                        throw new StackEmptyException();
                    }
                    return data[idx];
                }
            }
        }


        public bool IsEmpty
        {
            get
            {
                return this.data.Count == 0;
            }
        }


        public void Push(T val)
        {
            lock (data)
            {
                this.data.Add(val);
            }
        }

        private static object lockObj = new object();
        private object lockObj2 = new object();

        public T Pop()
        {
            lock (data) {
                int idx = this.data.Count - 1;
                if (idx == -1)
                {
                    throw new StackEmptyException();
                }
                T val = this.data[idx];
                this.data.RemoveAt(idx);
                return val;
            }
        }


        public class StackEmptyException : Exception
        {

        }
    }
}
