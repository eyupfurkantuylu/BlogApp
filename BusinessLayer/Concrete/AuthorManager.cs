using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authordal;

        public AuthorManager(IAuthorDal authordal)
        {
            _authordal = authordal;
        }

        public void AddT(Author t)
        {
            _authordal.Insert(t);
        }

        public void DeleteT(Author t)
        {
            _authordal.Delete(t);
        }

        public void UpdateT(Author t)
        {
            _authordal.Update(t);
        }

        public List<Author> GetList()
        {
            return _authordal.GetAll();
        }

        public Author GetById(int id)
        {
            return _authordal.GetByID(id);
        }

        public List<Author> GetAuthorById(int id)
        {
            return _authordal.GetAll(x => x.AuthorID == id);
        }
    }
}