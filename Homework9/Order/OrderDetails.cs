using System;
using System.ComponentModel.DataAnnotations;

namespace EF
{
    public class OrderDetails
    {
        [Key]
        public string Id { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public OrderDetails()
        {
            Id = Guid.NewGuid().ToString();
        }

        public OrderDetails(string id, string product, double price, int quantity)
        {
            Id = id;
            Product = product;
            Price = price;
            Quantity = quantity;
        }
    }
}