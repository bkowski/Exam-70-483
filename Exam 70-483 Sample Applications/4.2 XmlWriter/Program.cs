using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace _4._2_XmlWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWriter stream = new StringWriter();

            using(XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings(){Indent = true}))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("people");
                writer.WriteStartElement("person");
                writer.WriteAttributeString("firstname", "john");
                writer.WriteStartElement("contactdetails");
                writer.WriteElementString("emailaddress", "john@john.com");
                //writer.WriteEndElement();
                //writer.WriteEndElement();
                //writer.WriteEndElement();
                writer.Flush();
            }

            Console.WriteLine(stream.ToString());
            Console.ReadLine();
        }
    }
}
