using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._4_Binary_serialization
{
    [Serializable]
    class Product
    {
        private int _id;
        public string name;
        public decimal price;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
