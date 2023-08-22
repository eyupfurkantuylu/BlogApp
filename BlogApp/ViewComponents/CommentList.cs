using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1,
                    Username = "Eyüp"
                },
                new UserComment
                {
                    ID = 2,
                    Username = "Furkan"
                },
                new UserComment
                {
                    ID = 3,
                    Username = "Tüylü"
                },
            };
            return View(commentValues);
        }
    }
}