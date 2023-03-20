
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject_1_4.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_1_4.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var user = repo.GetAllUser();
            return View(user);
        }
        public IActionResult ViewUser(int id)
        {
            var user = repo.GetUser(id);

            return View(user);
        }

        public IActionResult UpdateUser(int id)
        {
            User use = repo.GetUser(id);
            if (use == null)
            {
                return View("UserNotFound");
            }
            return View(use);
        }

        public IActionResult UpdateUserToDatabase(User user)
        {
            repo.UpdateUser(user);

            return RedirectToAction("ViewUser", new { id = user.UserID });
        }

        public IActionResult InsertUser()
        {
            var use = repo.AssignCategory();
            return View(use);
        }

        public IActionResult InsertUserToDatabase(User userToInsert)
        {
            repo.InsertUser(userToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(User user)
        {
            repo.DeleteUser(user);
            return RedirectToAction("Index");
        }
    }
}

