using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_Implicit_conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Digit dig = new Digit(7);
            // implicit conversion
            double num = dig;

            // implicit conversion
            Digit dig2 = 12;

            Console.WriteLine("num = {0}, dig2 = {1}", num, dig2.val);
            Console.ReadLine();
        }
    }
}
