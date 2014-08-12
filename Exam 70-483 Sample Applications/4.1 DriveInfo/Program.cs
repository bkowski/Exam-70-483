using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4._1_DriveInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();

            foreach(DriveInfo driveInfo in drivesInfo)
            {
                Console.WriteLine("Drive {0}", driveInfo.Name);
                Console.WriteLine("File type: {0}", driveInfo.DriveType);

                if(driveInfo.IsReady == true)
                {
                    Console.WriteLine("Volume label: {0}", driveInfo.VolumeLabel);
                    Console.WriteLine("File system: {0}", driveInfo.DriveFormat);
                    Console.WriteLine("Available space to current user: {0, 15} bytes", driveInfo.AvailableFreeSpace);
                    Console.WriteLine("Total available space: {0, 15} bytes", driveInfo.TotalFreeSpace);
                    Console.WriteLine("Total size of drive: {0, 15}", driveInfo.TotalSize);
                }
            }
            Console.ReadLine();
        }
    }
}
