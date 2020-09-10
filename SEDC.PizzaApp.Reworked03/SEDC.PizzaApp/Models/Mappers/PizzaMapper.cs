using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Enums;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {

        public static PizzaViewModel ToPizzaViewModel(Pizza pizza)
        {
            if (pizza.HasExtras) 
            {
                return new PizzaViewModel
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    PizzaSize = pizza.PizzaSize,
                    Price = pizza.Price + 10
                    //HasExtras = pizza.HasExtras               
                };
            }
            else
            {
                return new PizzaViewModel
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    PizzaSize = pizza.PizzaSize,
                    Price = pizza.Price
                };
            }
        }

    }
}
