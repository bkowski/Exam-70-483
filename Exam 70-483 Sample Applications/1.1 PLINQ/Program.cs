using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //OrderedParallelQuery();
            AsSequential();
        }

        private static void UsingAsParallel()
        {
            var numbers = Enumerable.Range(0, 10000000);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0).ToArray();
        }

        private static void OrderedParallelQuery()
        {
            var numbers = Enumerable.Range(0, 10);
            var result = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0)
                .ToArray();

            foreach(int num in result)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }

        private static void AsSequential()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential();

            foreach(int i in parallelResult.Take(5))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        private static void UsingForAll()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0);

            parallelResult.ForAll(e => Console.WriteLine(e));
        }
    }
}
