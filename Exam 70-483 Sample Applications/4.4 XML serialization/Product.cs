using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace _4._4_XML_serialization
{
    public class Product // Class must be public for xml serialization
    {
        // Only public fields will be serialized

        private int _id;
        public string name;
        public decimal price;

        [XmlIgnore] // id will not be serialized
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
