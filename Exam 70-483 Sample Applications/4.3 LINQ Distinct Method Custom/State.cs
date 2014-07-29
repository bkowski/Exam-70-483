using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._3_LINQ_Distinct_Method_Custom
{
    class State : IEquatable<State>
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public bool Equals(State other)
        {
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            else
            {
                if(StateId == other.StateId && StateName == other.StateName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override int GetHashCode()
        {
            return StateId.GetHashCode() ^ StateName.GetHashCode();
        }
    }
}
