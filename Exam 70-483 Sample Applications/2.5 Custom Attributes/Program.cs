using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Custom_Attributes
{
    class Program
    {
        [Programmer("Brett Rutkowski")] // custom attribute marks this class's programmer as Brett Rutkowski and version 1.0
        static void Main(string[] args)
        {
        }
    }
}
