using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Extension_Methods
{
    public static class IntExtensions // class must be public and static for extension methods
    {
        public static int Half(this int x)
        {
            return x / 2;
        }

        public static int Add100(this int x)
        {
            return x + 100;
        }
    }
}
