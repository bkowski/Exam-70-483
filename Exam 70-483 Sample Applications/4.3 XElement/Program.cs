using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _4._3_XElement
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement xmlTree1 = new XElement("Root",
                new XElement("Child1", 1),
                new XElement("Child2", 2),
                new XElement("Child3", 3),
                new XElement("Child4", 4),
                new XElement("Child5", 5),
                new XElement("Child6", 6));

            XElement xmlTree2 = new XElement("Root",
                from el in xmlTree1.Elements()
                where ((int)el >= 3 && (int)el <= 5)
                select el
                    );

            Console.WriteLine(xmlTree2);
            Console.ReadLine();
        }
    }
}
