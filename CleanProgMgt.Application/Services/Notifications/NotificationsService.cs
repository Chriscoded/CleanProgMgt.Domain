using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Application.Services.Task;
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

        public bool MarkNotification(int notificationId, bool isRead)
        {
           return notificationRepository.MarkNotification(notificationId, isRead); ;
        }

        public Notification GetNotificationById(long? id)
        {
            var notification = notificationRepository.GetNotificationById(id);
            return notification;
        }

        public Notification Update(int id, NotificationCreateDto notificationChanges)
        {
            var notification = notificationRepository.Update(id,notificationChanges);
            return notification;
        }

        public Notification Delete(int id)
        {
            var notification = notificationRepository.Delete(id);
            return notification;
        }

        public List<Notification> GetTaskDueWithin48Hours()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return notificationRepository.GetAllNotifications();
        }

        public Notification AddNotification(Notification notification)
        {
            return notificationRepository.AddNotification(notification);
        }
    }
}
