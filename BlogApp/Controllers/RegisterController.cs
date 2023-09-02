using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{

    [AllowAnonymous]
    public class RegisterController : Controller
    {

        AuthorManager am = new AuthorManager(new EfAuthorRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Author author)
        {

            AuthorValidator vR = new AuthorValidator();

            ValidationResult result = vR.Validate(author);

            if (result.IsValid)
            {
                author.AuthorAbout = "deneme";
                author.AuthorStatus = true;
                author.AuthorRegistrationDate = DateTime.Now;
                author.AuthorImage = "/AuthorImageFiles/default.png";
                am.AddT(author);

                return RedirectToAction("Index", "Blog");
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