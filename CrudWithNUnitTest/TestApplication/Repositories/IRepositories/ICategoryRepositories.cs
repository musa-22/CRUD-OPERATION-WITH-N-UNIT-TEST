using TestApplication.Models.Domain;

namespace TestApplication.Repositories.IRepositories
{
    public interface ICategoryRepositories
    {

        Task <IEnumerable <Category>>  GetAllAsync();

        Task<Category> CreateAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task<Category> GetAsync(int id);
        Task<Category> DeleteAsync(Category category);


    }
}
