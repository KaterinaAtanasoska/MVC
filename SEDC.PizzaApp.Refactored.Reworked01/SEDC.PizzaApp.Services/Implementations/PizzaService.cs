using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Pizza;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class PizzaService: IPizzaService
    {
        private IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository ;
        }

        public void CreatePizza(PizzaViewModel pizzaViewModel)
        {
            Pizza pizza = pizzaViewModel.ToPizza();
            int newPizzaId = _pizzaRepository.Insert(pizza);
            if (newPizzaId <= 0)
            {
                throw new Exception("Something went wrong while saving the new pizza");
            }
        }

        public List<PizzaViewModel> GetAllPizzas()
        {
            List<Pizza> pizzas = _pizzaRepository.GetAll();
            List<PizzaViewModel> viewModels = new List<PizzaViewModel>();
            foreach (var pizza in pizzas)
            {
                viewModels.Add(pizza.ToPizzaViewModel());
            }

            return viewModels;
        }

        public PizzaViewModel GetPizzaById(int id)
        {
            Pizza pizza = _pizzaRepository.GetById(id);
            if (pizza == null)
            {
                
                throw new Exception($"Pizza with id {id} does not exist!");
            }

            return pizza.ToPizzaViewModel();
        }

        public List<PizzaDDViewModel> GetPizzasForDropdown()
        {
            List<Pizza> pizzas = _pizzaRepository.GetAll();
            List<PizzaDDViewModel> pizzaDdViewModels = new List<PizzaDDViewModel>();
            foreach (Pizza pizza in pizzas)
            {
                pizzaDdViewModels.Add(pizza.ToPizzaDdViewModel());
            }

            return pizzaDdViewModels;
        }
    }
}
