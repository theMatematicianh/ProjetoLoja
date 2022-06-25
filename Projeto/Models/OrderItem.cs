using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, double price,int id)
        {
            Id = id;
            Quantity = quantity;
            Price = price;
        }
        public double SubTotal()
        {
            return Price * Quantity;
        }
    }
}
