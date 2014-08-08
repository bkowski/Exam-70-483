using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_IComparable
{
    class Person : IComparable
    {
        private int _age;
        public int Age
        {
            get { return _age; }
        }
        public Person(int age)
        {
            _age = age;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Person p = obj as Person;
            if(p == null)
            {
                throw new ArgumentException("Object is not a Person");
            }

            return this._age.CompareTo(p._age);
        }
    }
}
