using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace _4._1_Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Carolyn\Numbers.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            for(int i = 0; i < 10; i++)
            {
                byte[] number = new UTF8Encoding(true).GetBytes(i.ToString());
                fs.Write(number, 0, number.Length);
            }

            fs.Close();
        }
    }
}
