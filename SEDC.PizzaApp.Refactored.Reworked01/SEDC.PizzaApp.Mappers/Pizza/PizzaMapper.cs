﻿using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Mappers.Pizza
{
    public static class PizzaMapper
    {
        public static PizzaDDViewModel ToPizzaDdViewModel(this Domain.Models.Pizza pizza)
        {
            return new PizzaDDViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name
            };
        }

        public static PizzaViewModel ToPizzaViewModel(this Domain.Models.Pizza pizza)
        {
           return new PizzaViewModel
           {
                Id = pizza.Id,
                Name = pizza.Name,
                IsOnPromotion = pizza.IsOnPromotion
            };
        }

        public static Domain.Models.Pizza ToPizza(this PizzaViewModel pizzaViewModel)
        {
            return new Domain.Models.Pizza
            {
                Id = pizzaViewModel.Id,
                Name = pizzaViewModel.Name,
                IsOnPromotion = pizzaViewModel.IsOnPromotion,
                PizzaOrders = new List<PizzaOrder> { }
            };
        }
    }
}
