using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3_Explicit_interface
{
    class Class1 : Interface1, Interface2
    {
        public void DoThis()
        {
            Console.WriteLine("Interface1 DoThis called");
        }

        public void DoThat()
        {
            throw new NotImplementedException();
        }

        void Interface2.DoThis()
        {
            Console.WriteLine("Interface2 DoThis called");
        }
    }
}
