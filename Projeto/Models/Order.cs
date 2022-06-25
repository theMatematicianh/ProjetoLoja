using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Moment { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();
        public double Total { get; set; }

        public Order()
        {
        }
        public Order(int id, DateTime moment)
        {
            Id = id;
            Moment = moment;
           
        }
        public void AddSales(OrderItem oi)
        {
            OrderItem.Add(oi);
        }
        public void RemoveSales(OrderItem oi)
        {
            OrderItem.Remove(oi);
        }
    }
}
