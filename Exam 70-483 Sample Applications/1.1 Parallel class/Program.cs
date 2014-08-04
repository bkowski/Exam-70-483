using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1_Parallel_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parallel for
            Console.WriteLine("Parallel.For started...");
            Parallel.For(0, 10, i =>
                {
                    System.Threading.Thread.Sleep(1000);
                });
            Console.WriteLine("Parallel.For finished...");

            Console.WriteLine("Parallel.ForEach started...");
            // Parallel foreach
            var range = Enumerable.Range(0, 10);           
            Parallel.ForEach(range, i =>
                {
                    System.Threading.Thread.Sleep(1000);
                });
            Console.WriteLine("Parallel.ForEach finished...");

            // Parallel invoke
            Parallel.Invoke(() =>
                {
                    Console.WriteLine("Begin first Parallel.Invoke task...");
                    int j = 1;
                    for (int i = 0; i <= 1000000; i++)
                        j++;
                    Console.WriteLine("First Parallel.Invoke task finished...");
                },
                () =>
                {
                    Console.WriteLine("Begin second Parallel.Invoke task...");
                    int j = 0;
                    var nums = Enumerable.Range(0, 200000);
                    foreach (int num in nums)
                    {
                        j++;
                    }
                    Console.WriteLine("Second Parallel.Invoke task finished...");
                },
                () =>
                {
                    Console.WriteLine("Begin third and final Parallel.Invoke task...");
                    int j = 1000;
                    for (int i = 10; i <= 10000; i++)
                        j++;
                    Console.WriteLine("Third Parallel.Invoke task finished...");
                });
            Console.ReadLine();
        }
    }
}
