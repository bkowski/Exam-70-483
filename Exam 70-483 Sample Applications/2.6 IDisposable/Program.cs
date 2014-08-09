using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6_IDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var file = new OpenFile("myFile.txt"))
            {

            }
        }
    }
}
