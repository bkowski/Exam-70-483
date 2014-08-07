using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Generics
{
    class GenericItems<T>
    {
        private T[] items = new T[50];
        private int numItems = 0;

        public void Add(T item)
        {
            if(numItems + 1 < 50)
            {
                items[numItems] = item;
                numItems++;
            }
        }

        public T this[int index]
        {
            get { return items[index]; }
        }
    }
}
