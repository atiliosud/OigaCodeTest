using Oiga.Bussines.Interface;
using Oiga.Bussines.Model;

namespace Oiga.Bussines.Service
{
    public class NotificationService : INotification
    {
        private List<Notification> notifications;

        public NotificationService()
        {
            notifications = new List<Notification>();
        }

        public void Handle(Notification notificacao)
        {
            notifications.Add(notificacao);
        }

        public List<Notification> GetNotification()
        {
            return notifications;
        }

        public bool HasNotification()
        {
            return notifications.Any();
        }
    }
}
