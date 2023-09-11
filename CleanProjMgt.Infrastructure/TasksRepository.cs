using CleanProgMgt.Application;
using CleanProgMgt.Domain;
using CleanProgMgt.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProjMgt.Infrastructure
{
    public class TasksRepository : ITasksRepository
    {
        //DateTime today = DateTime.Today;

        //DateTime fourDaysFromToday = today.AddDays(4);

        private readonly TasksDbContext taskDbContext;
        public TasksRepository(TasksDbContext taskDbContext)
        {
            this.taskDbContext = taskDbContext;
        }

        public static List<Tasks> tasks = new List<Tasks>()
        {
            new Tasks {Id = 1, Title = "Authentication", Description = "The authentication should be working before the end of the day", Due_date = DateTime.Today, Priority = Priority.Low , status= Status.Failed },
             new Tasks {Id = 1, Title = "OTP", Description = "The OTP should be working before the end of the day", Due_date = DateTime.Today, Priority = Priority.High , status= Status.Completed },
             new Tasks {Id = 1, Title = "OTP", Description = "The OTP should be working before the end of the day", Due_date = DateTime.Today, Priority = Priority.Medium , status= Status.In_progress }
        };

        public List<Tasks> GetAllTasks()
        {
            return taskDbContext.Tasks.ToList();
            
        }

        public Tasks CreateTask(Tasks task)
        {
            taskDbContext.Tasks.Add(task);
            taskDbContext.SaveChanges();    
            return task;
        }

        public Tasks GetTaskById(long? id)
        {
            var data = taskDbContext.Tasks.FirstOrDefault(x => x.Id == id);
            if (data == null)
                return null;
            else return data;
        }
    }
}
