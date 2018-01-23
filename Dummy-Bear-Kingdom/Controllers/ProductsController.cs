using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DummyBearKingdom.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DummyBearKingdom.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository productRepo;

        public ProductsController(IProductRepository repo = null)
        {
            if(repo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else 
            {
                this.productRepo = repo;
            }
        }

        public IActionResult Index()
        {
            
            return View(productRepo.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            productRepo.Save(product);
           
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var model = productRepo.Products
                                   .Include(p => p.Reviews)
                                   .FirstOrDefault(products => products.Id == id);

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(x => x.Id == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product thisProduct = productRepo.Products.FirstOrDefault(x => x.Id == id);
            productRepo.Remove(thisProduct);
            return RedirectToAction("Index");
        }

    }
}

