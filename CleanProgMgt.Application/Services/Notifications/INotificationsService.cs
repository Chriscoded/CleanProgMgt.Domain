using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Domain;

namespace CleanProgMgt.Application.Services.Notifications
{
    public interface INotificationsService
    {
        IEnumerable<Notification> GetAllNotifications();
        List<Notification> GetNotificationsForUser(int userId);
        Notification AddNotification(Notification notification);
        bool MarkNotification(int notificationId, bool isRead);
        Notification GetNotificationById(long? id);
        Notification Update(int id, NotificationCreateDto notificationChanges);
        Notification Delete(int id);
        List<Notification> GetTaskDueWithin48Hours();
    }
}
