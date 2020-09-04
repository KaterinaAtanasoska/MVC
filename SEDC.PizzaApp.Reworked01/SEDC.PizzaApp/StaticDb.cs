using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp
{
    public class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza()
            {
                Id=1,
                IsOnPromotion = true,
                Name="Margarita"
            },
            new Pizza()
            {
                Id=2,
                IsOnPromotion = false,
                Name="Capri"
            }
        };
    }
}
