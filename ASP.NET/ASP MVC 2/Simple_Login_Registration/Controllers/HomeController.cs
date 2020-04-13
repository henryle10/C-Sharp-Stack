using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple_Login_Registration.Models;

namespace Simple_Login_Registration.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("create/user")]
        public IActionResult CreateUser(IndexViewModel modelData)
        {
            User submittedUser = modelData.NewUser;
            if (ModelState.IsValid)
            {
                return RedirectToAction("success");
            }
            return View("Index");

        }
        [HttpPost("login/user")]
        public IActionResult LoginUser(IndexViewModel modelData)
        {
            Login submittedLogin = modelData.NewLogin;
            if (ModelState.IsValid)
            {
                return RedirectToAction("success");
            }
            return View("Index");
        }

        [HttpGet("success")]
        public IActionResult success()
        {
            return View();
        }
    }
}
