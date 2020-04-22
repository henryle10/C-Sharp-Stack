using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_Categories.Models;

namespace Products_Categories.Controllers
{
    public class CategoryController : Controller
    {
        private MyContext db;
        private int? cateId
        {
            get
            {
                return HttpContext.Session.GetInt32("cateId");
            }
        }
        public CategoryController(MyContext context)
        {
            db = context;
        }
        [HttpGet("/categories")]
        public IActionResult Categories()
        {
            List<Category> allcategories = db.Categories.ToList();
            ViewBag.categories = allcategories;
            return View();
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if (ModelState.IsValid == false)
            {
                return View("Categories");
            }

            db.Categories.Add(newCategory);
            db.SaveChanges();
            HttpContext.Session.SetInt32("cateId", newCategory.CategoryId);
            return RedirectToAction("Categories");
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Association newAssociation)
        {
            db.Add(newAssociation);
            db.SaveChanges();

            return RedirectToAction("DisplayCate", new { id = newAssociation.CategoryId });
        }

        [HttpGet("/categories/{Id}")]
        public IActionResult DisplayCate(int Id)
        {
            var selectedCate = db.Categories.Include(cate => cate.Associations).ThenInclude(associate => associate.AssociationCategories).FirstOrDefault(cate => cate.CategoryId == Id);

            var allAssociations = db.Associations.ToList();
            var allCategories = db.Categories.ToList();
            var allProducts = db.Products.ToList();

            List<Product> ProductWithoutAssociation = new List<Product>();

            if (selectedCate.Associations.Count() == 0)
            {
                foreach (var prod in allProducts)
                {
                    ProductWithoutAssociation.Add(prod);
                }
            }
            else
            {
                foreach (var prod in selectedCate.Associations)
                {
                    foreach (var a in allProducts)
                    {
                        if (prod.ProductId != a.ProductId)
                        {
                            ProductWithoutAssociation.Add(a);
                        }
                    }
                }
            }

            ViewBag.selectedCate = selectedCate;
            ViewBag.products = ProductWithoutAssociation;

            return View();
        }
    }
}