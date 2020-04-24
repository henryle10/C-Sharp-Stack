using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db;
        public HomeController(MyContext context)
        {
            db = context;
        }
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        //=====Login/Register Page====

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        //=====Dashboard Page======

        [HttpGet("/Dashboard")]
        public IActionResult Dashboard()
        {
            if (uid == null)
            {
                return RedirectToAction("Index");
            }

            List<Wedding> allWeddings = db.Weddings.Include(wed => wed.Creator).Include(wed => wed.ListPeople).ToList();

            ViewBag.uid = (int)uid;
            return View(allWeddings);
        }

        //=======New Wedding page======

        [HttpGet("/NewWedding")]
        public IActionResult NewWedding()
        {

            return View();
        }

        //=======Wedding Info Page=======
        [HttpGet("/Wedding/Info/{id}")]
        public IActionResult WeddingInfo(int id)
        {
            if (uid == null)
            {
                return View("Index");
            }
            Wedding SpecificWedding = db.Weddings.Include(wed => wed.ListPeople).ThenInclude(RSVP => RSVP.Attendee).FirstOrDefault(wed => wed.WeddingId == id);

            var now = DateTime.Now;
            if (SpecificWedding.Date < now)
            {
                db.Weddings.Remove(SpecificWedding);
                db.SaveChanges();
                return View("Dashboard");
            }
            return View("WeddingInfo", SpecificWedding);
        }

        [HttpPost("CreateWedding")]
        public IActionResult CreateWedding(Wedding newWedding)
        {
            if (uid == null)
            {
                return View("Index");
            }
            var PresentYear = DateTime.Now;
            if (newWedding.Date < PresentYear)
            {
                ModelState.AddModelError("Date", "Date cannot be in the past");
                return View("NewWedding");
            }
            if (ModelState.IsValid)
            {
                newWedding.UserId = (int)uid;
                db.Add(newWedding);
                db.SaveChanges();
                return RedirectToAction("WeddingInfo", new { id = newWedding.WeddingId });
            }
            return View("NewWedding");
        }

        [HttpPost("/register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "is taken");
                }
            }
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            newUser.CreatedAt = DateTime.Now;
            newUser.UpdatedAt = DateTime.Now;
            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard");
        }

        [HttpPost("Login")]
        public IActionResult LoginUser(LoginUser loginUser)
        {
            string errorMsg = "Invalid Email or Password";

            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            User dbUser = db.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

            if (dbUser == null)
            {
                ModelState.AddModelError("LoginEmail", errorMsg);
            }
            // user found in db
            else
            {
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                PasswordVerificationResult result = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

                if (result == 0)
                {
                    ModelState.AddModelError("LoginEmail", errorMsg);
                }
            }

            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            HttpContext.Session.SetString("FirstName", dbUser.FirstName);
            return RedirectToAction("Dashboard");
        }

        [HttpGet("UnRSVP/{id}")]
        public IActionResult UnRSVP(int id)
        {
            if (uid == null)
            {
                return View("Index");
            }
            else
            {
                var rsvp = db.Rsvps.FirstOrDefault(wedding => wedding.WeddingId == id);
                db.Rsvps.Remove(rsvp);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }


        [HttpGet("RSVP/{id}")]
        public IActionResult RSVP(int id)
        {
            if (uid == null)
            {
                return View("Index");
            }
            else
            {
                var rsvp = new RSVP
                {
                    WeddingId = id,
                    UserId = (int)uid
                };
                db.Rsvps.Add(rsvp);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (uid == null)
            {
                return View("Index");
            }
            else
            {
                Wedding SpecificWedding = db.Weddings.FirstOrDefault(wed => wed.WeddingId == id);

                db.Remove(SpecificWedding);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");

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
