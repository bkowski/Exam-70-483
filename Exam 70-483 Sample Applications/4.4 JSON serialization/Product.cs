using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace _4._4_JSON_serialization
{
    [DataContract]
    public class Product
    {
        [DataMember] // Required for every field you want to serialize
        private int _id;
        [DataMember]
        public string name;
        [DataMember]
        public decimal price;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
