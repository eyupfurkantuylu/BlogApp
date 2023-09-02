using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByAuthor(int id)
        {
            return _blogDal.GetListWithCategoryByAuthor(id);
        }
        
        
        
        public Blog GetById(int id)
        {
            return _blogDal.GetByID(id);
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAll(x => x.BlogID == id);
        }

        public void AddT(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void DeleteT(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void UpdateT(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }
        
        public List<Blog> GetBlogListByAuthor(int id)
        {

            return _blogDal.GetAll(x => x.AuthorID == id);
        }
    }
}