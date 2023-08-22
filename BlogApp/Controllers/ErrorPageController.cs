using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{
    public class ErrorPageController : Controller
    {

        public IActionResult Error1(int code)
        {
            return View();
        }

    }
}