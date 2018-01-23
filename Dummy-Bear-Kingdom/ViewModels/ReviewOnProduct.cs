using System;
using DummyBearKingdom.Models;

namespace DummyBearKingdom.ViewModels
{
    public class ReviewOnProduct
    {
        public int ReviewId { get; set; }
        public string Author { get; set; } = null;
        public string Content { get; set; } = null;
        public int Rating { get; set; }
        public Product Product { get; set; } = null;

        public ReviewOnProduct()
        {

        }
    }

   
}
