using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _4._3_LINQ_Distinct_Method_Custom
{
    class Program
    {
        static void Main(string[] args)
        {
            List<State> states = new List<State>()
            {
                new State() {StateId = 1, StateName = "NSW"},
                new State() {StateId = 2, StateName = "VIC"},
                new State() {StateId = 1, StateName = "NSW"},
                new State() {StateId = 3, StateName = "SA"}
            };

            var distinctStates = states.Distinct();

            foreach(State state in distinctStates)
            {
                Debug.WriteLine(state.StateName);
            }
        }
    }
}
