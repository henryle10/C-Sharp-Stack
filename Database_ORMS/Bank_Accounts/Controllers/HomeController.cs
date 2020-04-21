using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bank_Accounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Bank_Accounts.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db;
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        public HomeController(MyContext context)
        {
            db = context;
        }

        // =========Pages==========
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet("/account/{uid}")]
        public IActionResult Account()
        {
            int? uid = HttpContext.Session.GetInt32("UserId");

            User currentUser = db.Users.Include(user => user.Transactions)
            .FirstOrDefault(user => user.UserId == uid);


            if (uid == null)
            {
                return RedirectToAction("Login");
            }
            // ViewBag.ValidUser = db.Users.Include(user => user.Transactions).FirstOrDefault(user => user.UserId == uid);

            if (currentUser.Transactions != null)
            {
                currentUser.Transactions = currentUser.Transactions.OrderByDescending(trans => trans.CreatedAt).ToList();
            }

            ViewBag.User = currentUser;
            return View();
        }

        // =========Actions==========

        [HttpPost("LoginUser")]
        public IActionResult LoginUser(LoginUser loginUser)
        {
            string errorMsg = "Invalid Email or Password";

            if (ModelState.IsValid == false)
            {
                return View("Login");
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
                return View("Login");
            }

            HttpContext.Session.SetInt32("UserId", dbUser.UserId);

            return RedirectToAction("Account", new { uid });
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
            return RedirectToAction("Account", new { uid });
        }

        [HttpPost("account/{uid}")]
        public IActionResult Transactions(Transaction transaction)
        {
            User currentUser = db.Users.Include(user => user.Transactions)
            .FirstOrDefault(user => user.UserId == uid);

            if (ModelState.IsValid)
            {
                if (transaction.Amount < (0 - currentUser.Balance))
                {
                    ModelState.AddModelError("Amount", "Balance is insufficient");
                    ViewBag.User = currentUser;
                    if (currentUser.Transactions != null)
                    {
                        currentUser.Transactions = currentUser.Transactions.OrderByDescending(trans => trans.CreatedAt).ToList();
                    }
                    return View("Account");
                }
                transaction.UserId = currentUser.UserId;

                db.Transactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Account", new { uid });
            }
            ViewBag.User = currentUser;
            if (currentUser.Transactions != null)
            {
                currentUser.Transactions = currentUser.Transactions.OrderByDescending(trans => trans.CreatedAt).ToList();
            }
            return View("Account");
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
