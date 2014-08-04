﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2_Locking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            object _lock = new object(); // always make lock a reference type

            var up = Task.Run(() =>
                {
                    for (int i = 0; i < 1000000; i++)
                        lock (_lock) n++;
                });

            for (int i = 0; i < 1000000; i++)
                lock (_lock) n--;

            up.Wait();
            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
