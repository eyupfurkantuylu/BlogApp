using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddT(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void DeleteT(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void UpdateT(Category t)
        {
            _categoryDal.Update(t);
        }
        
        

        public Category GetById(int id)
        {
            return _categoryDal.GetByID(id);
        }


        public List<Category> GetList()
        {
            return _categoryDal.GetAll();
        }

    }
}

