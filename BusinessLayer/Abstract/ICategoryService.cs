using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface ICategoryService
	{
		void AddCategory(Category category);
		void DeleteCategory(Category category);
		void UpdateCategory(Category category);
		List<Category> GetList();
		Category GetById(int id);
	}
}

