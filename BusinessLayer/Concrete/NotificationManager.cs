using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NotificationManager:INotificationService
    {
        private INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void AddT(Notification t)
        {
            throw new NotImplementedException();
        }

        public void DeleteT(Notification t)
        {
            throw new NotImplementedException();
        }

        public void UpdateT(Notification t)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

