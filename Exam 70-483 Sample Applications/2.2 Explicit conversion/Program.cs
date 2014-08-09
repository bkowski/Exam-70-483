using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_Explicit_conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Fahrenheit fahr = new Fahrenheit(100.0f);
            Console.WriteLine("{0} fahrenheit", fahr.Degrees);
            Celsius c = (Celsius)fahr;
            Console.WriteLine("{0} celsius", c.Degrees);

            Fahrenheit fahr2 = (Fahrenheit)c;
            Console.WriteLine("{0} fahrenheit", fahr2.Degrees);

            Console.ReadLine();

        }
    }
}
