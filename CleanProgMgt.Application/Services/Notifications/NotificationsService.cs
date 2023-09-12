using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.Notifications
{
    public class NotificationsService :INotificationsService
    {
        private readonly INotificationRepository notificationRepository;

        public NotificationsService(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }
        public List<Notification> GetNotificationsForUser(int userId)
        {
            return notificationRepository.GetNotificationsForUser(userId);
        }

        public void AddNotification(int userId, string type, string message)
        {
            // Implement logic to add a new notification for a user
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            // Implement logic to mark a notification as read
        }

        public void MarkNotificationAsUnread(int notificationId)
        {
            // Implement logic to mark a notification as unread
        }
    }
}
