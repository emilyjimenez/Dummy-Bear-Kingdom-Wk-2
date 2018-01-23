using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DummyBearKingdom.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        DummyBearKingdomDbContext db = new DummyBearKingdomDbContext();

        public IQueryable<Review> Reviews
        { get { return db.Reviews; }}

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }
    }
}
