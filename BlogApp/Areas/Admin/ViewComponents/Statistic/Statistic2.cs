using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {       
        private Context c = new Context();
        
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x => x.BlogCreateDate).Select(x => x.BlogTitle).Take(1)
                .FirstOrDefault();
            return View();
        }
    }
}

