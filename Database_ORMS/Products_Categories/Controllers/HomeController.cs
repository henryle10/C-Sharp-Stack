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
    public class HomeController : Controller
    {
        private MyContext db;
        private int? prodId
        {
            get
            {
                return HttpContext.Session.GetInt32("prodId");
            }
        }
        public HomeController(MyContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            List<Product> allProducts = db.Products.ToList();
            ViewBag.Products = allProducts;
            return View();
        }

        [HttpPost("Create")]
        public IActionResult CreateProduct(Product newProduct)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            db.Products.Add(newProduct);
            db.SaveChanges();
            HttpContext.Session.SetInt32("prodId", newProduct.ProductId);
            return RedirectToAction("Index");
        }

        [HttpPost("AddCategory")]
        public IActionResult AddCategory(Association newAssociation)
        {
            db.Add(newAssociation);
            db.SaveChanges();

            return RedirectToAction("DisplayProd", new { id = newAssociation.ProductId });
        }

        [HttpGet("/products/{Id}")]
        public IActionResult DisplayProd(int Id)
        {
            var selectedProd = db.Products.Include(prod => prod.Associations).ThenInclude(associate => associate.AssociationProducts).FirstOrDefault(prod => prod.ProductId == Id);

            var allAssociations = db.Associations.ToList();
            var allCategories = db.Categories.ToList();
            var allProducts = db.Products.ToList();

            List<Category> CateogriesWithoutAssociation = new List<Category>();

            if (selectedProd.Associations.Count() == 0)
            {
                foreach (var cate in allCategories)
                {
                    CateogriesWithoutAssociation.Add(cate);
                }
            }
            else
            {
                foreach (var prod in selectedProd.Associations)
                {
                    foreach (var a in allCategories)
                    {
                        if (prod.CategoryId != a.CategoryId)
                        {
                            CateogriesWithoutAssociation.Add(a);
                        }
                    }
                }
            }

            ViewBag.selectedProd = selectedProd;
            ViewBag.categories = CateogriesWithoutAssociation;

            return View();
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
