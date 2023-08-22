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

        public void AddAuthor(Author author)
        {
            _authordal.Insert(author);
        }
    }
}