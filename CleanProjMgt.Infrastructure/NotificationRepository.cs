using CleanProgMgt.Application.Services.Notifications;
using CleanProgMgt.Domain;
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

        public void AddNotification(string userId, string type, string message)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetNotificationsForUser(int userId)
        {
            var data = dbContext.Notification.Where(n => n.UserId == userId)
                .ToList(); ;
            if (data == null)
                return null;
            else return data;
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            throw new NotImplementedException();
        }

        //public void AddNotification(string userId, string type, string message)
        //{
        //    // Implement logic to add a new notification for a user
        //}

        //public void MarkNotificationAsRead(int notificationId)
        //{
        //    // Implement logic to mark a notification as read
        //}

        public void MarkNotificationAsUnread(int notificationId)
        {
            // Implement logic to mark a notification as unread
        }

    }
}
