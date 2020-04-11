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
    }
}
