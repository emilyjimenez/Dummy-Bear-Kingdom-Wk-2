using Microsoft.VisualStudio.TestTools.UnitTesting;
using DummyBearKingdom.Models;
using System.IO;
using System;
using System.Collections.Generic;

namespace DummyBearKingdom.Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void GetAuthor_ReturnReviewAuthor_String()
        {
            //Arrange
            var review = new Review();

            //Act
            review.Author = "Someone";

            //Assert
            Assert.AreEqual("Someone", review.Author);
        }

        [TestMethod]
        public void GetContent_ReturnReviewContent_String()
        {
            //Arrange
            var review = new Review();

            //Act
            review.Content = "this is fine";
            //Assert
            Assert.AreEqual("this is fine", review.Content);
        }

        [TestMethod]
        public void GetRating_ReturnReviewRating_Int()
        {
            //Arrange
            var review = new Review();

            //Act
            review.Rating = 5;

            //Assert
            Assert.AreEqual(5, review.Rating);
        }

        [TestMethod]
        public void GetProductId_ReturnReviewProductId_Int()
        {
            //Arrange
            var review = new Review();

            //Act
            review.ProductId = 3;

            //Assert
            Assert.AreEqual(3, review.ProductId);
        }
    }
}
