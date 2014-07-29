using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;

namespace _4._1_DirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\");

            Debug.WriteLine("Directories in C drive:");
            foreach(DirectoryInfo di in directoryInfo.GetDirectories())
            {
                Debug.WriteLine(di.Name);
            }
        }
    }
}
