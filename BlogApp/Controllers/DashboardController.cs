using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        Context c = new Context();
        var userMail = User.Identity.Name;
        var authorId = c.Authors
            .Where(x => x.AuthorMail == userMail).Select(y => y.AuthorID)
            .FirstOrDefault();
        ViewBag.totalBlogCount = c.Blogs.Count().ToString();
        ViewBag.authorArticleCount = c.Blogs.Count(x => x.AuthorID == authorId).ToString();
        
        DateTime sevenDaysAgo = DateTime.Now.AddDays(-7);
        ViewBag.last7daysArticleCount = c.Blogs.Count(x => x.BlogCreateDate >= sevenDaysAgo && x.BlogCreateDate <= DateTime.Now).ToString();
        return View();
    }
}