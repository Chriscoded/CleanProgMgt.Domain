using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanProgMgt.Domain;

namespace CleanProgMgt.Application.Services.Notifications
{
    public interface INotificationsService
    {
        List<Notification> GetNotificationsForUser(int userId);
        void AddNotification(int userId, string type, string message);
        void MarkNotificationAsRead(int notificationId);
        void MarkNotificationAsUnread(int notificationId);
    }
}
