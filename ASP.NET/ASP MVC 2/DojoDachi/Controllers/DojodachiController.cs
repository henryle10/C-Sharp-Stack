using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoDachi.Models;
using Newtonsoft.Json;

namespace DojoDachi.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            DojodachiModels dachi = new DojodachiModels();
            HttpContext.Session.SetObjectAsJson("dachi", dachi);
            return View("Index", dachi);
        }

        [HttpPost("Feed")]
        public IActionResult Feed()
        {
            DojodachiModels dachi = HttpContext.Session.GetObjectFromJson<DojodachiModels>("dachi");
            Random randint = new Random();
            int RandChance = randint.Next(1, 5);
            if ((dachi.Meal - 1) < 0)
            {
                HttpContext.Session.SetString("Message", "Your dachi is out of meals!");
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                HttpContext.Session.SetString("Image", "~/images/sad_doge.jpg");
            }
            else
            {
                if (RandChance == 1)
                {
                    dachi.Meal -= 1;
                    HttpContext.Session.SetObjectAsJson("dachi", dachi);
                    HttpContext.Session.SetString("Message", "You fed your dojodachi but he threw it away");
                    HttpContext.Session.SetString("Image", "~/images/disgusted_doge.jpg");
                    return RedirectToAction("dojodachi");
                }
                dachi.Meal -= 1;
                Random rand = new Random();
                int newFullness = rand.Next(5, 11);
                dachi.Fullness += newFullness;
                string newFullnessString = newFullness.ToString();
                string message = "You fed your dojodachi. Fullness: +" + newFullnessString;
                HttpContext.Session.SetString("Message", message);
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                HttpContext.Session.SetString("Image", "~/images/eating_doge.png");
                return RedirectToAction("dojodachi");
            }
            return RedirectToAction("dojodachi");
        }

        [HttpPost("Play")]
        public IActionResult Play()
        {
            DojodachiModels dachi = HttpContext.Session.GetObjectFromJson<DojodachiModels>("dachi");
            Random randint = new Random();
            int RandChance = randint.Next(1, 5);
            if (dachi.Energy > 0)
            {
                if (RandChance == 1)
                {
                    dachi.Energy -= 5;
                    HttpContext.Session.SetObjectAsJson("dachi", dachi);
                    HttpContext.Session.SetString("Message", "You played with your dojodachi but he didnt like it");
                    HttpContext.Session.SetString("Image", "~/images/disgusted_doge.jpg");
                    return RedirectToAction("dojodachi");
                }
                else
                {
                    Random rand = new Random();
                    int newHappiness = rand.Next(5, 11);
                    dachi.Energy -= newHappiness;
                    dachi.Happiness += newHappiness;
                    string newHappinessString = newHappiness.ToString();
                    string message = "You Played with your dojodachi. Happiness: +" + newHappinessString + " Energy : -5";
                    HttpContext.Session.SetString("Message", message);
                    HttpContext.Session.SetObjectAsJson("dachi", dachi);
                    HttpContext.Session.SetString("Image", "~/images/playing_doge.jpg");
                }
                return RedirectToAction("dojodachi");
            }
            else
            {
                HttpContext.Session.SetString("Message", "Your dojodachi is out of energy!");
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                HttpContext.Session.SetString("Image", "~/images/sad_doge.jpg");
                return RedirectToAction("Playing");
            }
        }
        [HttpPost("Work")]
        public IActionResult Work()
        {
            DojodachiModels dachi = HttpContext.Session.GetObjectFromJson<DojodachiModels>("dachi");
            if (dachi.Energy > 0)
            {
                Random rand = new Random();
                int newMeal = rand.Next(1, 4);
                dachi.Meal += newMeal;
                dachi.Energy -= 5;
                string randMealString = newMeal.ToString();
                string message = "Your dojodachi worked hard! Meal: +" + randMealString + ". Energy: -5";
                HttpContext.Session.SetString("Message", message);
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                HttpContext.Session.SetString("Image", "~/images/working_doge.jpeg");
                return RedirectToAction("dojodachi");
            }
            else
            {
                HttpContext.Session.SetString("Message", "Your dojodachi is out of energy!");
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                HttpContext.Session.SetString("Image", "~/images/sad_dog.png");
                return RedirectToAction("dojodachi");
            }
        }
        [HttpPost("Sleep")]
        public IActionResult Sleep()
        {
            DojodachiModels dachi = HttpContext.Session.GetObjectFromJson<DojodachiModels>("dachi");
            dachi.Energy += 15;
            dachi.Fullness -= 5;
            dachi.Happiness -= 5;
            HttpContext.Session.SetString("Message", "Your Dojodachi slept. Fullness: -5. Happiness: -5. Energy: +15.");
            HttpContext.Session.SetObjectAsJson("dachi", dachi);
            HttpContext.Session.SetString("Image", "~/images/happy_doge.jpg");
            return RedirectToAction("dojodachi");
        }

        [HttpGet("dojodachi")]
        public IActionResult dojodachi()
        {
            DojodachiModels dachi = HttpContext.Session.GetObjectFromJson<DojodachiModels>("dachi");
            if (dachi.Energy >= 100 && dachi.Happiness >= 100 && dachi.Fullness >= 100)
            {
                HttpContext.Session.SetString("Message", "Congrats you won!");
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                HttpContext.Session.SetString("Image", "~/images/happy_doge.jpg");
                string images = HttpContext.Session.GetString("Image");
                ViewBag.Image = Url.Content(images);
                ViewBag.Message = HttpContext.Session.GetString("Message");
                return View("dojodachi", dachi);
            }
            else if (dachi.Fullness <= 0 || dachi.Happiness <= 0)
            {
                HttpContext.Session.SetString("Message", "Your Dojodachi has passed away...");
                HttpContext.Session.SetObjectAsJson("dachi", dachi);
                HttpContext.Session.SetString("Image", "~/images/dead_doge.jpg");
                string images = HttpContext.Session.GetString("Image");
                ViewBag.Image = Url.Content(images);
                ViewBag.Message = HttpContext.Session.GetString("Message");
                return View("dojodachi", dachi);
            }
            ViewBag.Message = HttpContext.Session.GetString("Message");
            string image = HttpContext.Session.GetString("Image");
            ViewBag.Image = Url.Content(image);
            return View("dojodachi", dachi);
        }

        [HttpGet("win")]
        public IActionResult Win()
        {
            DojodachiModels dachi = HttpContext.Session.GetObjectFromJson<DojodachiModels>("dachi");
            ViewBag.Message = "Congratulations! You Won!";
            return View("Win", dachi);
        }

        [HttpGet("lose")]
        public IActionResult Lose()
        {
            DojodachiModels dachi = HttpContext.Session.GetObjectFromJson<DojodachiModels>("dachi");
            HttpContext.Session.SetString("Message", "Your Dojodachi has passed away...");
            HttpContext.Session.SetObjectAsJson("dachi", dachi);
            HttpContext.Session.SetString("Image", "~/images/sad_doge.jpg");
            return RedirectToAction("dojodachi");
        }
    }
}


public static class SessionExtensions
{
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        string value = session.GetString(key);
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}

