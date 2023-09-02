using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager:IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddT(Message t)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(Message t)
        {
            throw new NotImplementedException();
        }

        public void UpdateT(Message t)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetList()
        {
            return _messageDal.GetAll();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListByAuthor(string email)
        {
            return _messageDal.GetAll(x=>x.Receiver == email);
        }
    }
}

