using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4_Covariance
{
    class Mammals { }
    class Dogs : Mammals { }
    class Program
    {
        // define the delegate
        public delegate Mammals HandlerMethod();

        public static Mammals MammalsHandler()
        {
            return null;
        }

        public static Dogs DogsHandler()
        {
            return null;
        }
        static void Main(string[] args)
        {
            HandlerMethod handlerMammals = MammalsHandler;

            // Covariance enables this assignment
            HandlerMethod handlerDogs = DogsHandler;
        }
    }
}
