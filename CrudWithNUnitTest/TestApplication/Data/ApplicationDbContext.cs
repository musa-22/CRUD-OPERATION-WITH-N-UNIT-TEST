
using Microsoft.EntityFrameworkCore;
using TestApplication.Models.Domain;

namespace TestApplication.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) :base(dbContext) 
        {
            
        }


        public DbSet<Category> CategoriesDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                { 
                    Id = 1,

                    category= "Sound Like Pound"
            
            
            });
        }
    }

}
