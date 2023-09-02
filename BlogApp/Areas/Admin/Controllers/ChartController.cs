using BlogApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
  
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryCountModel> list = new List<CategoryCountModel>();
            
            list.Add(new CategoryCountModel
            {
                CategoryName = "Teknoloji",
                CategoryCount = 10
            });
            
            list.Add(new CategoryCountModel
            {
                CategoryName = "Yazılım",
                CategoryCount = 14
            });
            
            list.Add(new CategoryCountModel
            {
                CategoryName = "Spor",
                CategoryCount = 5
            });

            return Json(new { jsonlist = list });
        }
        
        
    }
}

