using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    
    public class Message2Manager: IMessage2Service
    {
         IMessage2Dal _message2Dal;

         public Message2Manager(IMessage2Dal message2Dal)
         {
             _message2Dal = message2Dal;
         }


         public void AddT(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void UpdateT(Message2 t)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetList()
        {
            return _message2Dal.GetAll();
        }

        public Message2 GetById(int id)
        {
            return _message2Dal.GetByID(id);
        }

        public Message2 GetByIdWithAuthor(int id)
        {
            return _message2Dal.GetByIdWithAuthor(id);
        }

        public List<Message2> GetInboxListByAuthor(int id)
        {
            return _message2Dal.GetListWithMessageByAuthor(id);
        }
        
    }
}
