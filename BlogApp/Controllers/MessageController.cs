using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class MessageController : Controller
    {
        private Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        private Context c = new Context();
        // GET
        public IActionResult InBox()
        {
            
            var userMail = User.Identity.Name;

            var authorId = c.Authors
                .Where(x => x.AuthorMail == userMail).Select(y => y.AuthorID)
                .FirstOrDefault();
            
            var values = mm.GetInboxListByAuthor(authorId);
            return View(values);
        }
        
        
        [HttpGet]
        public IActionResult MessageDetail(int id)
        {
            var value = mm.GetByIdWithAuthor(id);
            
            return View(value);
        }
        
        
        
    }
}

