
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Controllers
{
    public class CategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}

