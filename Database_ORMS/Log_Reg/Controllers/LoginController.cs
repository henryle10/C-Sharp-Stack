using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Log_Reg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

public class LoginController : Controller
{
    private LoginContext db;

    public LoginController(LoginContext context)
    {
        db = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet("/success")]
    public IActionResult Success()
    {
        return View();
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
        return RedirectToAction("Success");
    }

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

        return RedirectToAction("Success");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}