
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListByAuthor(int id);

    }
}