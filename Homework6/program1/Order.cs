using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class Order
    {
        public string Name;
        public string Clent;
        public List<OrderDetails> Items;
        public Order() { }
        public Order(string name, string clent)
        {
            Name = name; Clent = clent; Items = new List<OrderDetails>();
        }
    }
}
