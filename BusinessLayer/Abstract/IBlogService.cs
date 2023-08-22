
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void AddBlog(Blog blog);
        void DeleteBlog(Blog blog);
        void UpdateBlog(Blog blog);
        List<Blog> GetList();
        Blog GetById(int id);
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListByAuthor(int id);

    }
}