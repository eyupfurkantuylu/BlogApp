using System;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
	public interface IBlogDal : IGenericDal<Blog>
	{
		List<Blog> GetListWithCategory();
		List<Blog> GetListWithCategoryByAuthor(int id);
	}
}

