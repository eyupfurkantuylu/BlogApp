using System;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		void Insert(T t);
		void Delete(T t);
		void Update(T t);
		List<T> GetAll();
		T GetByID(int id);
		List<T> GetAll(Expression<Func<T, bool>> filter);
	}
}

