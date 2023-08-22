using System;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context context = new Context();

        public void Delete(T t)
        {
            context.Remove(t);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            context.Add(t);
            context.SaveChanges();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter).ToList();
        }

        public void Update(T t)
        {
            context.Update(t);
            context.SaveChanges();
        }
    }
}

