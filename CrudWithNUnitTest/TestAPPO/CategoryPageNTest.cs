using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Controllers;
using TestApplication.Repositories.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApplication.Models;
using TestApplication.Models.Domain;
using NUnit.Framework.Legacy;

namespace TestAPPO
{
    [TestFixture]
    public class CategoryPageNTest
    {
        private Mock<ICategoryRepositories> _repository;
        private CategoryController _categoryController;
       
        [TearDown]
        public void TearDown()
        {
           
            _categoryController?.Dispose();
        }

        [SetUp]
        public void Setup()
        {
           
            _repository = new Mock<ICategoryRepositories>();
 
            _categoryController = new CategoryController(_repository.Object);
        }

       

        [Test]
        public async Task TestIndexPage_ReturnsViewResult_WithCategories()
        {
            // Arrange
            var mockCategories = new List<Category>
            {
                new Category { Id = 1, category = "Sam" },
                new Category { Id = 2,  category = "Smith" }
            };

            _repository.Setup(r => r.GetAllAsync()).ReturnsAsync(mockCategories);

            // Act
            var result = await _categoryController.Index() as ViewResult;

            // Assert
            ClassicAssert.IsNotNull(result);
         

            var model = result.Model as List<Category>;
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(2, model.Count);
            ClassicAssert.AreEqual("Sam", model[0].category, "The first category name should be Sam");
        }
    }
}
