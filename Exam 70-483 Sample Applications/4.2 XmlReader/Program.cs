using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace _4._2_XmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            using(XmlReader xmlReader = XmlReader.Create("People.xml", new XmlReaderSettings() { IgnoreWhitespace = true}))
            {
                xmlReader.MoveToContent();
                xmlReader.ReadStartElement("people");

                string firstname = xmlReader.GetAttribute("firstname");
                string lastname = xmlReader.GetAttribute("lastname");

                Console.WriteLine("Person: {0} {1}", firstname, lastname);
                xmlReader.ReadStartElement("person");

                Console.WriteLine("Contact Details");

                xmlReader.ReadStartElement("contactdetails");
                xmlReader.ReadStartElement("emailaddress");
                string email = xmlReader.Value;

                Console.WriteLine("Email address: {0}", email);
                
            }
            Console.ReadLine();
        }
    }
}
