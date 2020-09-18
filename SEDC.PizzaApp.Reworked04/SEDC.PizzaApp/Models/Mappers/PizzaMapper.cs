using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaDDViewModel ToPizzaDDViewModel(Pizza pizza)
        {
            return new PizzaDDViewModel
            {
                Id = pizza.Id,
                PizzaName = pizza.Name
            };
        }
        public static PizzaViewModel ToPizzaViewModel(Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                PizzaName = pizza.Name,
                Price = pizza.Price
            };
        }
        public static Pizza ToPizza(PizzaViewModel pizzaViewModel)
        {

            return new Pizza
            {
                Id = pizzaViewModel.Id,
                Name = pizzaViewModel.PizzaName,
                Price = pizzaViewModel.Price
            };
        }
    }
}
