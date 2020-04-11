using System;
using Microsoft.AspNetCore.Mvc;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Stringz lorem = new Stringz()
            {
                Para = "  Lorem ipsum dolor, sit amet consectetur adipisicing elit. Numquam, repellat ipsam? Adipisci vitae repellat ipsum repellendus tempore. Inventore, fuga accusamus sed asperiores praesentium exercitationem facilis aperiam qui vitae, aut esse Lorem ipsum dolor, sit amet consectetur adipisicing elit. Numquam, repellat ipsam? Adipisci vitae repellat ipsum repellendus tempore. Inventore, fuga accusamus sed asperiores praesentium exercitationem facilis aperiam qui vitae, aut esseLorem ipsum dolor, sit amet consectetur adipisicing elit. Numquam, repellat ipsam? Adipisci vitae repellat ipsum repellendus tempore. Inventore, fuga accusamus sed asperiores praesentium exercitationem facilis aperiam qui vitae, aut esse ",
            };
            return View("Index", lorem);
        }

        [HttpGet("/numbers")]
        public IActionResult Numbers()
        {
            int[] viewModel = new int[]
            {
                1,2,3,4,5,25,32,65
            };
            return View("numbers", viewModel);
        }

        [HttpGet("/users")]
        public IActionResult Users()
        {
            string[] users = new string[]
            {
                "Henry Le", "Justin", "Derek"
            };
            return View("users", users);
        }

        [HttpGet("/user")]
        public IActionResult OneUser()
        {
            User Henry = new User()
            {
                FirstName = "Henry",
                LastName = "Le",
            };
            return View("user", Henry);
        }

    }
}
