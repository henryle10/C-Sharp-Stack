using System;
using Microsoft.AspNetCore.Mvc;

namespace Time_Display.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}