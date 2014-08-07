using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericItems<int> genericInts = new GenericItems<int>();
            genericInts.Add(50);
            genericInts.Add(33);

            Console.WriteLine(genericInts[1]);
            

            GenericItems<string> genericStr = new GenericItems<string>();
            genericStr.Add("Brett");
            genericStr.Add("Rules!!!");
            Console.WriteLine(genericStr[0] + " " + genericStr[1]);
            Console.ReadLine();
        }
    }
}
