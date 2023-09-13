using CleanProgMgt.Application.Services.Notifications;
using CleanProgMgt.Domain;
using CleanProgMgt.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProjMgt.Infrastructure
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TasksDbContext dbContext;

        public NotificationRepository(TasksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Notification AddNotification(Notification notification)
        {
            dbContext.Notification.Add(notification);
            dbContext.SaveChanges();
            return notification;
        }

        public Notification Delete(int id)
        {
            var notification = dbContext.Notification.Find(id);
            if (notification != null)
            {
                dbContext.Notification.Remove(notification);
                dbContext.SaveChanges();
            }
            return notification;
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return dbContext.Notification;
        }

        public Notification GetNotificationById(long? id)
        {
            var data = dbContext.Notification.FirstOrDefault(x => x.Id == id);
            if (data == null)
                return null;
            else return data;
        }

        public List<Notification> GetNotificationsForUser(int userId)
        {
            var data = dbContext.Notification.Where(n => n.UserId == userId)
                .ToList(); ;
            if (data == null)
                return null;
            else return data;
        }

        
        public bool MarkNotification(int notificationId, bool isRead)
        {
            var notification = dbContext.Notification.FirstOrDefault(n => n.Id == notificationId);
            if (notification != null)
            {
                if (isRead)
                notification.Status = NotificationStatus.Read;
                else
                    notification.Status = NotificationStatus.Unread;
                return true;
            }
            return false;
        }

        public Notification Update(Notification notificationChanges)
        {
            throw new NotImplementedException();
        }


    }
}
