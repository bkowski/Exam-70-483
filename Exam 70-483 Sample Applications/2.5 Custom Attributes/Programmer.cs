using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Custom_Attributes
{
    // this allows the attribute to only be applied to class and struct declarations
    // AllowMultiple allows multiple attributes of the same type
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    class Programmer : Attribute // custom attributes must inherit from Attribute
    {
        private string name;
        public double version;

        public Programmer(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }
}
