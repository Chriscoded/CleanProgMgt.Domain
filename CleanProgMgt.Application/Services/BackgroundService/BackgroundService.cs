using CleanProgMgt.Application.Services.Notifications;
using CleanProgMgt.Application.Services.Task;
using CleanProgMgt.Domain.Enums;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CleanProgMgt.Application.Services.BackgroundService
{
    public class BackgroundService : IBackgroundServices
    {
        private readonly ITasksService tasksService;
        private readonly INotificationsService notificationsService;
        private readonly ILogger<BackgroundService> logger;

        public BackgroundService(ITasksService tasksService, 
            INotificationsService notificationsService,
            ILogger<BackgroundService> logger)
        {
            this.tasksService = tasksService;
            this.notificationsService = notificationsService;
            this.logger = logger;
        }
        public void tasksDueSoon()
        {
            var tasksDue = tasksService.GetTasksDueWithin48Hours();

            foreach (var task in tasksDue)
            {
                var notification = new Notification
                {
                    Due_date = DateTime.Now,
                    Message = "Your task is due",
                    Type = NotificationTypes.due_date_reminder,
                    Status = NotificationStatus.Unread,
                    UserId = task.UserId
                };

                // Create a notification for the task's due date
                notificationsService.AddNotification(notification);
                Console.WriteLine("Due task Notified");

                logger.LogInformation("Due task Notified");
                logger.LogInformation($"{ tasksDue}");
            }

        }

        public void test()
        {
            Console.WriteLine("Test");
        }
    }
}
