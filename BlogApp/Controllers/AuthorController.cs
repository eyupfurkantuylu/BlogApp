using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{
    public class AuthorController : Controller
    {

        [AllowAnonymous]
        public IActionResult Index()
        {
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

    }
}