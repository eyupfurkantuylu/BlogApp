using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal:IGenericDal<Message2>
    {
        Message2 GetByIdWithAuthor(int id);
        List<Message2> GetListWithMessageByAuthor(int id);
    }
}

