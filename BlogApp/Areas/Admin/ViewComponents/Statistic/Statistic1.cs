using System.Xml.Linq;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        private BlogManager bm = new BlogManager(new EfBlogRepository());
        private Context c = new Context();
        
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            ViewBag.v4 = "5";
            
            // TODO: HAVA DURUMU API'SI AKTIF OLUNCA BURAYI AKTİF ET!
            // string api = "cea41f26c9fe651ef6d6c917726ab17c";
            // string connection =
            //     "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            // XDocument document = XDocument.Load(connection);
            // ViewBag.v4 = document.Descendants("temprature").ElementAt(0).Attribute("value").Value;
            //
            return View();
        }
    }
}

