using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    
    public interface IMessage2Service : IGenericService<Message2>
    {
        Message2 GetByIdWithAuthor(int id);
        List<Message2> GetInboxListByAuthor(int id);
    }
}
