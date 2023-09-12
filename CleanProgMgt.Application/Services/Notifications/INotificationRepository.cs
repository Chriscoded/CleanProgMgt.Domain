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
        List<Notification> GetNotificationsForUser(int userId);
        void AddNotification(string userId, string type, string message);
        void MarkNotificationAsRead(int notificationId);
        void MarkNotificationAsUnread(int notificationId);
    }
}
