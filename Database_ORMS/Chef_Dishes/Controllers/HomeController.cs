using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chef_Dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace Chef_Dishes.Controllers
{
    public class HomeController : Controller
    {
        private DishContext db;
        public HomeController(DishContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            List<Chef> AllChefs = db.Chefs.Include(chef => chef.CreatedDishes)
            .ToList();
            return View(AllChefs);
        }

        [HttpGet("/dishes/new")]

        public IActionResult NewDish()
        {
            List<Chef> AllChefs = db.Chefs.ToList();
            ViewBag.Chefs = AllChefs;
            return View();
        }

        [HttpGet("/dishes")]
        public IActionResult Dishes()
        {
            List<Dish> allDishes = db.Dishes
            .Include(dish => dish.Creator)
            .ToList();
            return View(allDishes);
        }

        [HttpGet("/new")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost("/new/chef")]
        public IActionResult addChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                db.Add(newChef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("NewChef");
        }

        [HttpPost("/new/dish")]
        public IActionResult addDish(Dish newDish)
        {
            if (ModelState.IsValid == false)
            {
                return View("NewDish");
            }
            db.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("Dishes");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
