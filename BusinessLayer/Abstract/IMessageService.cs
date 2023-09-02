using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> GetInboxListByAuthor(string email);
    }
}

