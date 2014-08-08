using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2._4_IEnumerable
{
    class NRLTeams : IEnumerable
    {
        private Team[] teams;
        public NRLTeams(Team[] teamArray)
        {
            teams = new Team[teamArray.Length];

            for(int i = 0; i < teamArray.Length; i++)
            {
                teams[i] = teamArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
        
        public NRLTeamsEnum GetEnumerator()
        {
            return new NRLTeamsEnum(teams);
        }
    }
}
