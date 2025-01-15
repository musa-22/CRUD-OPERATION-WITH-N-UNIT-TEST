using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.Repositories.IRepositories;

namespace TestApplication.Controllers
{

    public class CategoryController : Controller
    {

        private  ICategoryRepositories  _categoryRep;

        public CategoryController(ICategoryRepositories categoryRepositories)
        {
          this._categoryRep = categoryRepositories;
        }




        public async Task <IActionResult> Index()
        {
          var getCategories = await _categoryRep.GetAllAsync();

            return View(getCategories); 
        }




    }
}
