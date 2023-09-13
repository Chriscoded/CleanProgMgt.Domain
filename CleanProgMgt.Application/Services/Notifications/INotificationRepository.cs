using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.Notifications
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetAllNotifications();
        List<Notification> GetNotificationsForUser(int userId);
        Notification AddNotification(Notification notification);
        bool MarkNotification(int notificationId, bool isRead);
        Notification GetNotificationById(long? id);
        Notification Update(Notification notificationChanges);
        Notification Delete(int id);
    }
}
