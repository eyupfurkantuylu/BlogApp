using BlogApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogApp.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class AuthorController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthorList()
        {
            var jsonAuthors = JsonConvert.SerializeObject(authors);
            return Json(jsonAuthors);

        }

        public IActionResult GetAuthorById(int authorId)
        {
            var result = authors.FirstOrDefault(x => x.Id == authorId);
            var jsonResult = JsonConvert.SerializeObject(result);
            return Json(jsonResult);

        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorModel author)
        {
            authors.Add(author);
            var jsonResult = JsonConvert.SerializeObject(author);
            return Json(jsonResult);
        }
        
        
        public IActionResult DeleteAuthor(int id)
        {
            var author = authors.FirstOrDefault(x => x.Id == id);
            authors.Remove(author);
            return Json(author);
        }

        public IActionResult UpdateAuthor(AuthorModel w)
        {
            var author = authors.FirstOrDefault(x => x.Id == w.Id);
            author.Name = w.Name;
            var jsonResult = JsonConvert.SerializeObject(w);
           
            return Json(jsonResult);

        }
        

        public static List<AuthorModel> authors = new List<AuthorModel>
        {
            new AuthorModel
            {
                Id = 1,
                Name = "Eyüp"
            },
            new AuthorModel
            {
                Id = 2,
                Name = "Furkan"
            },
            new AuthorModel
            {
                Id = 3,
                Name = "Tüylü"
            }
        };


    }
}
