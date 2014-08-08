using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            Team[] teamArray = new Team[5]
            {
                new Team("Eels"),
                new Team("Sharks"),
                new Team("Roosters"),
                new Team("Cowboys"),
                new Team("Storm")
            };

            NRLTeams teams = new NRLTeams(teamArray);
            foreach(Team t in teams)
            {
                Console.WriteLine(t.name);
            }
            Console.ReadLine();
        }
    }
}
