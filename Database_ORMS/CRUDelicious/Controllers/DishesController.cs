using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

public class DishesController : Controller
{
    private DishContext db;

    public DishesController(DishContext context)
    {
        db = context;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> Dishes = db.Dishes.ToList();
        return View(Dishes);
    }

    [HttpGet("/new")]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost("/Dish/Create")]
    public IActionResult addDish(Dish newDish)
    {
        if (ModelState.IsValid == false)
        {
            return View("new");
        }
        db.Dishes.Add(newDish);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("/Dish/{DishId}")]
    public IActionResult Details(int dishId)
    {
        Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        if (selectedDish == null)
        {
            return RedirectToAction("/");
        }
        return View(selectedDish);
    }

    [HttpGet("/Dish/{DishId}/Edit")]
    public IActionResult Edit(int dishId)
    {
        Dish dishToEdit = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        if (dishToEdit == null)
        {
            return RedirectToAction("Index");
        }
        return View(dishToEdit);
    }
    [HttpPost("/Dish/Update")]
    public IActionResult Update(Dish editedDish, int dishId)
    {
        if (ModelState.IsValid == false)
        {
            return View("Edit", editedDish);
        }
        Dish dbDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        if (dbDish == null)
        {
            return RedirectToAction("Index");
        }

        dbDish.Name = editedDish.Name;
        dbDish.Chef = editedDish.Chef;
        dbDish.Calories = editedDish.Calories;
        dbDish.Tastiness = editedDish.Tastiness;
        dbDish.Description = editedDish.Description;
        dbDish.UpdatedAt = DateTime.Now;

        db.Dishes.Update(dbDish);
        db.SaveChanges();

        return RedirectToAction("Details", dbDish);
    }


    [HttpGet("/Dish/{DishId}/Delete")]
    public IActionResult Delete(int dishId)
    {
        Dish dishToDelete = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        db.Dishes.Remove(dishToDelete);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}

