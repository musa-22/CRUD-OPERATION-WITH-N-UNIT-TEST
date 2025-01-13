using Microsoft.AspNetCore.Mvc;

namespace TestApplication.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
