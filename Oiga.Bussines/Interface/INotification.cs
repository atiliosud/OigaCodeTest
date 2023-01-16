using Oiga.Bussines.Model;

namespace Oiga.Bussines.Interface
{
    public interface INotification
    {
        bool HasNotification();
        List<Notification> GetNotification();
        void Handle(Notification notification);
    }
}
