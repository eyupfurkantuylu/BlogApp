using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();


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
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            var categoryName = cm.GetById(values[0].CategoryID);
            values[0].Category = categoryName;
            
            return View(values);
        }

        public IActionResult BlogListByAuthor()
        {
            var userMail = User.Identity.Name;
            var authorId = c.Authors
                .Where(x => x.AuthorMail == userMail).Select(y => y.AuthorID)
                .FirstOrDefault();

            
            var values = bm.GetListWithCategoryByAuthor(authorId);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryID.ToString()
                    }
                ).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            BlogValidator vR = new BlogValidator();
            ValidationResult result = vR.Validate(blog);
            
            var userMail = User.Identity.Name;

            var authorId = c.Authors
                .Where(x => x.AuthorMail == userMail).Select(y => y.AuthorID)
                .FirstOrDefault();
            

            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Now;
                blog.AuthorID = authorId;
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

        public IActionResult DeleteBlog(int id)
        {
            var blogValue = bm.GetById(id);
            bm.DeleteT(blogValue);
            return RedirectToAction("BlogListByAuthor");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogValue = bm.GetById(id);
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryID.ToString()
                    }
                ).ToList();
            ViewBag.cv = categoryValues;
            return View(blogValue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            bm.UpdateT(blog);
            return RedirectToAction("BlogListByAuthor");
        }

    }
}

