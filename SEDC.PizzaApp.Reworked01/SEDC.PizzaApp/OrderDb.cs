using SEDC.PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp
{
    public class OrderDb
    {
        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                Name = "Capri"
            },
            new Order
            {
                Id = 2,
                Name = "Margherita"
            },
            new Order
            {
                Id = 3,
                Name = "Quattro Formaggi"
            }
        };
    }
}
