using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("Orders")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Order order = OrderDb.Orders.FirstOrDefault(x => x.Id == id);
                return View(order);
            }
            return new EmptyResult();
        }

        public IActionResult JsonData()
        {
            Order order = new Order
            {
                Id = 1,
                Name = "Capri"
            };
            return new JsonResult(order); 
        }

        public IActionResult BackToHome()
        {
            return RedirectToAction("Index", "Home"); 
        }
    }
}
