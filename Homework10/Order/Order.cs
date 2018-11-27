using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class Order
    {
        [Key]
        public String Id { get; set; }
        public String Customer { get; set; }
        public List<OrderDetails> Items { get; set; }

        public Order()
        {
            Items = new List<OrderDetails>();
        }

        public Order(string id, string customer, List<OrderDetails> items)
        {
            Id = id;
            Customer = customer;
            Items = items;
        }
    }
}
