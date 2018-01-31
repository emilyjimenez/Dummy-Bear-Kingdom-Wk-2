using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Linq;
using DummyBearKingdom.Controllers;
using DummyBearKingdom.Models;


namespace DummyBearKingdom.Tests.ControllerTests
{
    [TestClass]
    public class ProductsControllerTests
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { Id = 1, Cost = 10, Description = "Dummy Bear shaped lollipop with rainbow sprinkles", Name = "Dummy Bear Pop" },
                new Product { Id = 2, Cost = 100, Description = "Contains all magic spells from the CareBears, including the Care Bear stare", Name = "Care Bear Spellbook"}

            }.AsQueryable()); 
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult()
        {
            //Arrange
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List()
        {
            //Arrange
            DbSetup();
            ViewResult indexView = new ProductsController(mock.Object).Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Product>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsItems_Collection()
        {
            //Arrange
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);
            Product testProduct = new Product();
            testProduct.Name = "Dummy Bear Pop";
            testProduct.Description = "Dummy Bear shaped lollipop with rainbow sprinkles";
            testProduct.Cost = 10;
            testProduct.Id = 1;

            //Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Product> collection = indexView.ViewData.Model as List<Product>;

            //Assert
            CollectionAssert.Contains(collection, testProduct);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            //Arrange
            Product testProduct = new Product
            {
                Id = 1,
                Cost = 10,
                Description = "Dummy Bear shaped lollipop with rainbow sprinkles",
                Name = "Dummy Bear Pop"
            };

            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            //Act
            var resultView = controller.Create(testProduct) as ViewResult;


            //Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            //Arrange
            Product testProduct = new Product
            {
                Id = 1,
                Cost = 10,
                Description = "Dummy Bear shaped lollipop with rainbow sprinkles",
                Name = "Dummy Bear Pop"
            };

            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);

            //Act
            var resultView = controller.Details(testProduct.Id) as ViewResult;
            var model = resultView.ViewData.Model as Product;

            //Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Product));
        }

        [TestMethod]
        public void DeleteProduct_DeleteProductFromCollection()
        {
            //Arrange
            DbSetup();
            ProductsController controller = new ProductsController(mock.Object);
            Product testProduct = new Product
            {
                Id = 1,
                Cost = 10,
                Description = "Dummy Bear shaped lollipop with rainbow sprinkles",
                Name = "Dummy Bear Pop"
            };
            Product testProduct2 = new Product
            {
                Id = 2,
                Cost = 100,
                Description = "Contains all magic spells from the CareBears, including the Care Bear stare",
                Name = "Care Bear Spellbook"
            };

            //Act
            controller.Create(testProduct);
            controller.Create(testProduct2);

            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;
            controller.DeleteConfirmed(collection[0].Id);
            var collection2 = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            //Assert
            CollectionAssert.DoesNotContain(collection2, testProduct);
            
        }
      
    }
}
