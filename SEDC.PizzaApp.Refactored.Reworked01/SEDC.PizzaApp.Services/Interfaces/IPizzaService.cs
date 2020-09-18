using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaViewModel> GetAllPizzas();
        List<PizzaDDViewModel> GetPizzasForDropdown();
        PizzaViewModel GetPizzaById(int id);
        void CreatePizza(PizzaViewModel pizzaViewModel);
    }
}
