using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            List<PizzaViewModel> pizzaViewModels = _pizzaService.GetAllPizzas();
            return View(pizzaViewModels);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                PizzaViewModel pizzaViewModel = _pizzaService.GetPizzaById(id.Value);
                return View(pizzaViewModel);
            }
            catch (Exception ex)
            {
                return View("ExceptionView");
            }
        }

        public IActionResult CreatePizza()
        {
            PizzaViewModel pizzaViewModel = new PizzaViewModel();
            return View(pizzaViewModel);
        }

        [HttpPost]
        public IActionResult CreatePizzaPost(PizzaViewModel pizzaViewModel)
        {
            try
            {
                _pizzaService.CreatePizza(pizzaViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionView");
            }

        }
    }
}
