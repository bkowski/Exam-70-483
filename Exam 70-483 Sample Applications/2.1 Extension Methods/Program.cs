using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = 100.Half();
            int answer2 = 100.Add100();

            Console.WriteLine("Half: {0}, Add100: {1}", answer, answer2);
            Console.ReadLine();
        }
    }
}
