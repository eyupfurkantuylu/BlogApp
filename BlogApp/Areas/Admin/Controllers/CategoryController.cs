using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        
        public IActionResult Index(int page=1)
        {
            //TODO: SAYFALAMA YAPISI BURADA KULLANILDI - X.PagedList ve X.PagedList.Mvc.Core Kütüphaneleri eklendi
            var values = cm.GetList().ToPagedList(page,5);
            return View(values);
        }

        
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            
            CategoryValidator vR = new CategoryValidator();
            ValidationResult result = vR.Validate(category);
            
            if (result.IsValid)
            {
                category.CategoryStatus = true;
                cm.AddT(category);

                return RedirectToAction("Index", "Category");
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

        public IActionResult DeleteCategory(int id)
        {
            var value = cm.GetById(id);
            cm.DeleteT(value);

            return RedirectToAction("Index");
        }
        
        
    }
}

