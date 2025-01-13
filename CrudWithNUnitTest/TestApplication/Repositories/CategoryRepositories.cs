using Microsoft.EntityFrameworkCore;
using TestApplication.Data;
using TestApplication.Models.Domain;
using TestApplication.Repositories.IRepositories;

namespace TestApplication.Repositories
{
    public class CategoryRepositories : ICategoryRepositories
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepositories(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.CategoriesDb.ToListAsync();
        }

        public async Task<Category> CreateAsync(Category category)
        {
           await _db.AddAsync(category);
           await _db.SaveChangesAsync();

            return category; 
        }



        public async Task<Category> GetAsync(int id)
        {

            if (id <= 0)
            {
                throw new ArgumentException("Id can not be zero and it must be greater.");
            }

            return await _db.CategoriesDb.FirstOrDefaultAsync(x => x.Id == id);
            
        }


        public async Task<Category> UpdateAsync(Category category)
        {
           
            var existingCategory = await _db.CategoriesDb.FirstOrDefaultAsync(x => x.Id == category.Id);

            
            if (existingCategory is not null)
            {
               
                existingCategory.category = category.category;

                 _db.Update(existingCategory);
                await _db.SaveChangesAsync();
            }

           
            return existingCategory;
        }

        public async Task<Category> DeleteAsync(Category category)
        {
            var getData = await _db.CategoriesDb.FirstOrDefaultAsync(x => x.Id == category.Id);

            if (getData is  null) 
            {
                return null;
            }
            _db.CategoriesDb.Remove(getData);
            await _db.SaveChangesAsync();

            return getData;

        }

      
       
    }
}
