using CleanProgMgt.Application.Dtos;
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
            return dbContext.Notification
                .Include(not=> not.User)
                .ToList();
        }

        public Notification GetNotificationById(long? id)
        {
            var data = dbContext.Notification
                .Include(not=> not.User)
                .FirstOrDefault(x => x.Id == id);
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

        public Notification Update(int id, NotificationCreateDto notificationChanges)
        {
            //user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var notificationToUpdate = dbContext.Notification.Find(id);

            if (notificationToUpdate == null)
            {
                // Handle not found error, e.g., throw an exception
                return null;
            }

            // Update the task properties with values from the DTO
            notificationToUpdate.Message = notificationChanges.Message;
            notificationToUpdate.Type = notificationChanges.Type;
            notificationToUpdate.Status = notificationChanges.Status;
            notificationToUpdate.Due_date = notificationChanges.Due_date;
            notificationToUpdate.UserId = notificationChanges.UserId;
            //notificationToUpdate.Timestamp = notificationChanges.Timestamp;
            // Update other properties as needed

            dbContext.SaveChanges();
            return notificationToUpdate;
        }


    }
}
