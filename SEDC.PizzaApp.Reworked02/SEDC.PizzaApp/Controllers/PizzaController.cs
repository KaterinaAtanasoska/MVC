using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            ViewData["Title"] = "Pizza List";
            List<Pizza> pizzas = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaViewModel = new List<PizzaViewModel>();
            foreach (Pizza pizza in pizzas)
            {
                pizzaViewModel.Add(PizzaMapper.ToPizzaViewModel(pizza));
            }
            return View(pizzaViewModel); // returns ViewResult
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
                Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
                ViewData["Title"] = "Pizza Details";
                ViewBag.Pizza = pizza;
                return View();
            }
            return new EmptyResult();
        }

    }
}