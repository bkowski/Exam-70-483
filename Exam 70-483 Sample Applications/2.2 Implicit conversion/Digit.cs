using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_Implicit_conversion
{
    class Digit
    {
        public Digit(double d)
        {
            val = d;
        }

        public double val;

        public static implicit operator double(Digit d)
        {
            return d.val;
        }

        public static implicit operator Digit(double d)
        {
            return new Digit(d);
        }
    }
}
