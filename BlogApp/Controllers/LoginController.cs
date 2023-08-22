using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Author author)
        {
            Context c = new Context();
            var data = c.Authors.FirstOrDefault(
                x =>
                x.AuthorMail == author.AuthorMail &&
                x.AuthorPassword == author.AuthorPassword
            );

            if (data != null)
            {
                HttpContext.Session.SetString("username", author.AuthorMail);
                return RedirectToAction("Index", "Author");
            }
            else
            {
                return View();
            }


        }

    }
}