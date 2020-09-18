using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> pizzas = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaViewModels = new List<PizzaViewModel>();
            foreach (var pizza in pizzas)
            {
                pizzaViewModels.Add(PizzaMapper.ToPizzaViewModel(pizza));
            }
            return View(pizzaViewModels); // returns ViewResult
        }

        public IActionResult JsonData()
        {
            Pizza pizza = new Pizza
            {
                Id = 1,
                Name = "Capri"
            };
            return new JsonResult(pizza); // returns JsonResult
        }

        public IActionResult BackToHome()
        {
            return RedirectToAction("Index", "Home"); //redirects to Action Index in Home Controller
        }

        public IActionResult Details(int? id) // localhost:port/Pizza/Details/1 or  localhost:port/Pizza/Details
        {
            if (id != null)
            {
                return View();
            }
            //  return new EmptyResult();
            return View("BadRequest");
        }

        public IActionResult CreatePizza()
        { 
        PizzaViewModel pizzaViewModel = new PizzaViewModel();
            return View(pizzaViewModel);
        }

        public IActionResult CreatePizzaPost(PizzaViewModel pizzaViewModel)
        {
            pizzaViewModel.Id = ++StaticDb.PizzaId;

            StaticDb.Pizzas.Add(PizzaMapper.ToPizza(pizzaViewModel));
            return RedirectToAction("Index");
        }

        public IActionResult EditPizza(int? id)
        {
            
            if (id == null)
            {
                return View("BadRequest");
            }
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                return View("ResourceNotFound");
            }

            PizzaViewModel pizzaViewModel = PizzaMapper.ToPizzaViewModel(pizza);
            return View(pizzaViewModel);
        }


        [HttpPost]
        public IActionResult EditPizzaPost(PizzaViewModel pizzaViewModel)
        {
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == pizzaViewModel.Id);
            if (pizza == null)
                return View("ResourceNotFound");


            Pizza editedPizza = PizzaMapper.ToPizza(pizzaViewModel);
            int i = StaticDb.Pizzas.IndexOf(pizza);
            StaticDb.Pizzas[i] = editedPizza;

            return RedirectToAction("Index");
        }

        public IActionResult DeletePizza(int? id)
        {
            if (id == null)
                return View("BadRequest");

            Order order = StaticDb.Orders.FirstOrDefault(p => p.Pizza.Id == id);

            if (order != null)
            {
                return View("ForbiddenAction");
            }

            //we are sending view model to the view
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id); ;
            PizzaViewModel pizzaViewModel = PizzaMapper.ToPizzaViewModel(pizza);

            return View(pizzaViewModel);
        }

        [HttpPost]
        public IActionResult DeletePizzaPost(PizzaViewModel pizzaViewModel)
        {
            //find the index of the order
            var index = StaticDb.Pizzas.FindIndex(x => x.Id == pizzaViewModel.Id);
            //check if the order exists
            if (index == -1)
                return View("ResourceNotFound");
            StaticDb.Pizzas.RemoveAt(index);
            return RedirectToAction("Index");
        }
    }
}