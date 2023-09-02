using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository: GenericRepository<Message2>, IMessage2Dal 
    {
        public Message2? GetByIdWithAuthor(int id)
        {
            using (var c = new Context())
            {
                var message =  c.Message2s
                    .Include(x => x.SenderUser)
                    .Include(x=>x.ReceiverUser)
                    .FirstOrDefault(x =>x.MessageID == id);
                return message;
            }
        }
        public List<Message2> GetListWithMessageByAuthor(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s
                    .Include(x => x.SenderUser)
                    .Include(x=>x.ReceiverUser)
                    .Where(x=>x.ReceiverID == id).ToList();
            }
        }
    }
}

