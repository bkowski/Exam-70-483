using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4_Breakpoints
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(int num in Enumerable.Range(1,50))
            {
                // breakpoint is set to fire when hit count equals 20
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
    }
}
