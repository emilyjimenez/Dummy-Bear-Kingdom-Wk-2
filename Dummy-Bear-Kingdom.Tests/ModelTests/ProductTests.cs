using Microsoft.VisualStudio.TestTools.UnitTesting;
using DummyBearKingdom.Models;
using System.IO;
using System;
using System.Collections.Generic;

namespace DummyBearKingdom.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void GetCost_ReturnProductCost_Int()
        {
            //Arrange
            var product = new Product();

            //Act
            product.Cost = 10;

            //Assert
            Assert.AreEqual(10, product.Cost);
        }

        [TestMethod]
        public void GetDescription_ReturnProductDescription_String()
        {
            //Arrange
            var product = new Product();

            //Act
            product.Description = "this is a description";

            //Assert
            Assert.AreEqual("this is a description", product.Description);
        }

        [TestMethod]
        public void GetName_ReturnProductName_String()
        {
            //Arrange
            var product = new Product();

            //Act
            product.Name = "Care Bear Spellbook";

            //Assert
            Assert.AreEqual("Care Bear Spellbook", product.Name);
        }
    }
}
