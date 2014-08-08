using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3_Explicit_interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1();
            // implicit
            c.DoThis();
            
            // explicit
            Interface2 i2 = c;
            i2.DoThis();

            Console.ReadLine();
        }
    }
}
