using System;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey.Models;

namespace Dojo_Survey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("/result")]
        public ViewResult Result(User newUser)
        {
            return View("result", newUser);
        }

        [HttpPost("/register")]
        public RedirectToActionResult Register(User newUser)
        {
            return RedirectToAction("result", newUser);
        }
    }
}
