using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    public class OrderDetails
    {
        public string Num;
        public string Product;
        public double Price;
        public OrderDetails() { }
        public OrderDetails(string num, string product, double price)
        {
            Num = num; Product = product; Price = price;
        }
    }
}
