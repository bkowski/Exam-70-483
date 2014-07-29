using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;

namespace _4._1_StreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Carolyn\Numbers2.txt");
            Debug.WriteLine("Char by Char");
            while(!sr.EndOfStream)
            {
                Debug.WriteLine((char)sr.Read());
            }

            sr.Close();

            sr = new StreamReader(@"C:\Users\Carolyn\Numbers2.txt");
            Debug.WriteLine("Line by Line");
            while(!sr.EndOfStream)
            {
                Debug.WriteLine((string)sr.ReadLine());
            }

            sr.Close();

            sr = new StreamReader(@"C:\Users\Carolyn\Numbers2.txt");
            Debug.WriteLine("Entire File");
            while(!sr.EndOfStream)
            {
                Debug.WriteLine((string)sr.ReadToEnd());
            }

            sr.Close();
        }
    }
}
