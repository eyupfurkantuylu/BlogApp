using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());


        // GET: /<controller>/
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogDetails(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByAuthor()
        {
            var values = bm.GetBlogListByAuthor(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            
            BlogValidator vR = new BlogValidator();

            ValidationResult result = vR.Validate(blog);

            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Now;
                blog.AuthorID = 1;
                bm.AddT(blog);

                return RedirectToAction("BlogListByAuthor", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }


    }
}

