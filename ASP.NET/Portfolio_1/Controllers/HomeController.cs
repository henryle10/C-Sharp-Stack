using System;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("index");
        }

        [HttpGet("projects")]
        public ViewResult Projects()
        {
            return View("Projects");
        }

        [HttpGet("contacts")]
        public ViewResult Contacts()
        {
            return View("Contacts");
        }
    }
}