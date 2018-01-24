using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DummyBearKingdom.Models;
using DummyBearKingdom.ViewModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DummyBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        //private IProductRepository productRepo;


        private IReviewRepository reviewRepo;

        public ReviewsController(IReviewRepository repo = null)
        {
            
            if(repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }


        }
      
        public IActionResult Index()
        {
            return View(reviewRepo.Reviews.ToList());
        }

        public IActionResult Create(int id)
        {
            ReviewOnProduct reviewonproduct = new ReviewOnProduct(id);
            return View(reviewonproduct);
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
           

            //ViewBag.Id = new SelectList(productRepo.Products.ToList(), "Id", "Name");
            reviewRepo.Save(review);

            return RedirectToAction("Details", "Products", new { id = review.ProductId});
        }
    }
}
