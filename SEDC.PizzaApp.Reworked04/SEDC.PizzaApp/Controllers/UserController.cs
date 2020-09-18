using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<User> users = StaticDb.Users;
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (var user in users)
            {
                userViewModels.Add(UserMapper.ToUserViewModel(user));
            }
            return View(userViewModels); 
        }

        public IActionResult CreateUser()
        {
            UserViewModel userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult CreateUserPost(UserViewModel userViewModel)
        {
            userViewModel.Id = ++StaticDb.UserId;

            StaticDb.Users.Add(UserMapper.ToUser(userViewModel));
            return RedirectToAction("Index");
        }
        public IActionResult EditUser(int? id)
        {

            if (id == null)
            {
                return View("BadRequest");
            }
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return View("ResourceNotFound");
            }

            UserViewModel userViewModel = UserMapper.ToUserViewModel(user);
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult EditUserPost(UserViewModel userViewModel)
        {
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == userViewModel.Id);
            if (user == null)
                return View("ResourceNotFound");


            User editedUser = UserMapper.ToUser(userViewModel);
            int i = StaticDb.Users.IndexOf(user);
            StaticDb.Users[i] = editedUser;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(int? id)
        {
            if (id == null)
                return View("BadRequest");

            Order order = StaticDb.Orders.FirstOrDefault(p => p.User.Id == id);

            if (order != null)
            {
                return View("ForbiddenAction");
            }

            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id); ;
            UserViewModel userViewModel = UserMapper.ToUserViewModel(user);

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult DeleteUserPost(UserViewModel userViewModel)
        {
            
            var index = StaticDb.Users.FindIndex(x => x.Id == userViewModel.Id);
            
            if (index == -1)
                return View("ResourceNotFound");
            StaticDb.Users.RemoveAt(index);
            return RedirectToAction("Index");
        }
    }
}
