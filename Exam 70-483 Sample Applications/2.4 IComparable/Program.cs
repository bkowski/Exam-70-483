using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4_IComparable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person(12),
                new Person(33),
                new Person(9),
                new Person(2),
                new Person(66)
            };

            people.Sort();

            foreach(Person p in people)
            {
                Console.WriteLine(p.Age);
            }
            Console.ReadLine();
        }
    }
}
