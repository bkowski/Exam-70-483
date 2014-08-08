using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2._4_IEnumerable
{
    class NRLTeamsEnum : IEnumerator
    {
        public Team[] teams;

        // Enumerators are positioned before the first element 
        // until the first MoveNext() call. 
        int position = -1;

        public NRLTeamsEnum(Team[] list)
        {
            teams = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < teams.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public Team Current
        {
            get
            {
                try
                {
                    return teams[position];
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
