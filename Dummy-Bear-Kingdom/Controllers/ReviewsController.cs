﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using DummyBearKingdom.Models;
using DummyBearKingdom.ViewModels;
using System.IO;
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

        public IActionResult Create(int productId)
        {
            ReviewOnProduct reviewonproduct = new ReviewOnProduct(productId);
            return View(reviewonproduct);
        }

        [HttpPost]
        public IActionResult Create(ReviewOnProduct review)
        {
            //need to change review to type Review
            Review newReview = new Review();
            newReview.ReviewId = review.ReviewId;
            newReview.Author = review.Author;
            newReview.Content = review.Content;
            newReview.Rating = review.Rating;
            newReview.ProductId = review.ProductId;


            //need to pass in object of type Review
            reviewRepo.Save(newReview);

            return RedirectToAction("Details", "Products", new { id = review.ProductId});
        }
    }
}
