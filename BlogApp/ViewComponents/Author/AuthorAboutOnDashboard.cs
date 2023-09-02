using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Author
{
    

    public class AuthorAboutOnDashboard:ViewComponent
    {
        AuthorManager am = new AuthorManager(new EfAuthorRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            var authorId = c.Authors
                .Where(x => x.AuthorMail == userMail).Select(y => y.AuthorID)
                .FirstOrDefault();
            
            var values = am.GetAuthorById(authorId);
            return View(values);
        }
        
    }
}