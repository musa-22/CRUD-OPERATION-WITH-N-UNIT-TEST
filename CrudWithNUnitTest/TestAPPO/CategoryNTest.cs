using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using TestApplication.Data;
using TestApplication.Models.Domain;
using TestApplication.Repositories;

namespace TestAPPO
{
    [TestFixture]
    public class CategoryNTest
    {
        private Category createCategory;

        private  DbContextOptions<ApplicationDbContext> options;
       
        public CategoryNTest()
        {
            
            createCategory = new Category()
            {
                Id = 3,
                category = "Musa"
            };

        }
        
        [SetUp]
        public void Setup()
        {

            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
        }

       

        [Test]
        public async Task Save_CategoryData_Inot_Database()
        {
            // Arrange
          


            // Act
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new CategoryRepositories(context);
                await repo.CreateAsync(createCategory); 
            }

            // Assert
            using (var context = new ApplicationDbContext(options))
            {
                var categoryFromDb = await context.CategoriesDb.FirstOrDefaultAsync(u => u.Id == 3);

               
                ClassicAssert.NotNull(categoryFromDb);
                ClassicAssert.AreEqual(createCategory.category, categoryFromDb.category);
                ClassicAssert.AreEqual(createCategory.Id, categoryFromDb.Id);
            }
        }


        [Test]
        public async Task Check_All_CategoriesFromDb()
        {
            // Arrange
            var expectedCategories = new List<Category> { createCategory };


            // Insert the category data into the database
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new CategoryRepositories(context);
                await repo.CreateAsync(createCategory);
            }

            // Act: 
            List<Category> actualCategories;
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new CategoryRepositories(context);
                actualCategories = (await repo.GetAllAsync()).ToList();
            }

            // Assert
            ClassicAssert.NotNull(actualCategories);
            ClassicAssert.AreEqual(expectedCategories.Count, actualCategories.Count);

        }



        [Test]
        public async Task Get_Single_Category_Data()
        {
            // Arrange

            Category createCategory = new() 
            { 
                Id = 3,
                category = "Musa"
            }; 



            // Insert the category into the database
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new CategoryRepositories(context);
                await repo.CreateAsync(createCategory);
            }

            // Act: 
            Category categoryFromDb;
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new CategoryRepositories(context);
                categoryFromDb = await repo.GetAsync(createCategory.Id);
            }

            // Assert
            ClassicAssert.NotNull(categoryFromDb);
            ClassicAssert.AreEqual(createCategory.category, categoryFromDb.category);
            ClassicAssert.AreEqual(createCategory.Id, categoryFromDb.Id);
        }

        [Test]
        public async Task Check_If_Category_was_updated()
        {
           
                // Arrange: 
              

                // Initial category to create
                var createCategory = new Category()
                {
                    Id = 3, 
                    category = "Musa"
                };

                // Category after the update
                var updatedCategory = new Category()
                {
                    Id = 3, 
                    category = "Ali" 
                };

               
                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new CategoryRepositories(context);
                    await repo.CreateAsync(createCategory);  
                    await context.SaveChangesAsync();  
                }

                // Act: Update the category 
                using (var context = new ApplicationDbContext(options))
                {
                    var repo = new CategoryRepositories(context);
                    await repo.UpdateAsync(updatedCategory);  
                    await context.SaveChangesAsync();  
                }


                // Assert: 
                using (var context = new ApplicationDbContext(options))
                {
                    var categoryFromDb = await context.CategoriesDb.FirstOrDefaultAsync(u => u.Id == 3);

             
                    ClassicAssert.NotNull(categoryFromDb);
                    ClassicAssert.AreEqual(updatedCategory.category, categoryFromDb.category);
                    ClassicAssert.AreEqual(updatedCategory.Id, categoryFromDb.Id);
                }
            }


        [Test]
        public async Task Check_if_Category_Data_Deleted()
        {
            // Arrange
            var category = new Category { Id = 1, category = "Test Category" };

            
            using (var context = new ApplicationDbContext(options))
            {
                await context.CategoriesDb.AddAsync(category);
                await context.SaveChangesAsync();
            }

            // Act:
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new CategoryRepositories(context);
                await repo.DeleteAsync(category); 
                await context.SaveChangesAsync();
            }

            // Assert:
            using (var context = new ApplicationDbContext(options))
            {
                var deletedCategory = await context.CategoriesDb.FirstOrDefaultAsync(x => x.Id == category.Id);
                ClassicAssert.IsNull(deletedCategory); 
            }
        }



    }

}

