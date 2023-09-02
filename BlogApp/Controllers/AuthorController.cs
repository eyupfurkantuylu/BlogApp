using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace BlogApp.Controllers
{
    public class AuthorController : Controller
    {
        AuthorManager am = new AuthorManager(new EfAuthorRepository());

        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.userMail = userMail;

            Context c = new Context();

            var authorName = c.Authors
                .Where(x => x.AuthorMail == userMail).Select(y => y.AuthorName)
                .FirstOrDefault();
            ViewBag.authorName = authorName;
            
            return View();
        }

        public IActionResult AuthorProfile()
        {
            return View();
        }

        public IActionResult AuthorMail()
        {
            return View();
        }


        public PartialViewResult AuthorNavbarPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult AuthorEditProfile()
        {
            var userMail = User.Identity.Name;
            Context c = new Context();

            var authorId = c.Authors
                .Where(x => x.AuthorMail == userMail).Select(y => y.AuthorID)
                .FirstOrDefault();
            var authorValues = am.GetById(authorId);
            return View(authorValues);
        }

        [HttpPost]
        public IActionResult AuthorEditProfile(Author author)
        {
            AuthorValidator av = new AuthorValidator();
            ValidationResult results = av.Validate(author);
            if (results.IsValid)
            {
                am.UpdateT(author);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(AddProfileImage author)
        {
            Author newAuthor = new Author();

            if (author.AuthorImage != null)
            {
                var extension = Path.GetExtension(author.AuthorImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AuthorImageFiles", imageName);
                var stream = new FileStream(location, FileMode.Create);
                author.AuthorImage.CopyTo(stream);
                newAuthor.AuthorImage = "/AuthorImageFiles" + imageName;
            }

            newAuthor.AuthorID = author.AuthorID;
            newAuthor.AuthorName = author.AuthorName;
            newAuthor.AuthorAbout = author.AuthorAbout;
            newAuthor.AuthorMail = author.AuthorMail;
            newAuthor.AuthorEmailConfirmed = author.AuthorEmailConfirmed;
            newAuthor.AuthorLastLogin = author.AuthorLastLogin;
            newAuthor.AuthorLastLoginIP = author.AuthorLastLoginIP;
            newAuthor.AuthorBirthDate = author.AuthorBirthDate;
            newAuthor.AuthorLanguages = author.AuthorLanguages;
            newAuthor.AuthorContactEmail = author.AuthorContactEmail;
            newAuthor.AuthorContactPhoneNumber = author.AuthorContactPhoneNumber;
            newAuthor.AuthorPassword = author.AuthorPassword;
            newAuthor.AuthorStatus = true;
            newAuthor.AuthorFacebookProfile = author.AuthorFacebookProfile;
            newAuthor.AuthorTwitterProfile = author.AuthorTwitterProfile;
            newAuthor.AuthorLinkedInProfile = author.AuthorLinkedInProfile;
            newAuthor.AuthorCountry = author.AuthorCountry;
            newAuthor.AuthorCity = author.AuthorCity;
            newAuthor.AuthorNeighborhood = author.AuthorNeighborhood;
            newAuthor.AuthorStreet = author.AuthorStreet;
            newAuthor.AuthorZipCode = author.AuthorZipCode;
            newAuthor.AuthorPhoneNumber = author.AuthorPhoneNumber;
            newAuthor.PersonalWebsite = author.PersonalWebsite;
            newAuthor.AuthorResume = author.AuthorResume;


            am.AddT(newAuthor);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}