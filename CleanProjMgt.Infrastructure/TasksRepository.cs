using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Application.Services.Task;
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

        private readonly TasksDbContext dbContext;
        public TasksRepository(TasksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public static List<Tasks> tasks = new List<Tasks>()
        //{
        //    new Tasks {Id = 1, Title = "Authentication", Description = "The authentication should be working before the end of the day", Due_date = DateTime.Today, Priority = Priority.Low , status= Status.Failed },
        //     new Tasks {Id = 1, Title = "OTP", Description = "The OTP should be working before the end of the day", Due_date = DateTime.Today, Priority = Priority.High , status= Status.Completed },
        //     new Tasks {Id = 1, Title = "OTP", Description = "The OTP should be working before the end of the day", Due_date = DateTime.Today, Priority = Priority.Medium , status= Status.In_progress }
        //};

        public IEnumerable<Tasks> GetAllTasks()
        {
            return dbContext.Tasks;
            
        }

        public Tasks CreateTask(Tasks task)
        {
            dbContext.Tasks.Add(task);
            dbContext.SaveChanges();    
            return task;
        }

        public Tasks GetTaskById(long? id)
        {
            var data = dbContext.Tasks.FirstOrDefault(x => x.Id == id);
            if (data == null)
                return null;
            else return data;
        }

        public Tasks Update(int id, TaskCreateDto taskChanges)
        {
            //user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var taskToUpdate = dbContext.Tasks.Find(id);

            if (taskToUpdate == null)
            {
                // Handle not found error, e.g., throw an exception
                return null;
            }

            // Update the task properties with values from the DTO
            taskToUpdate.Title = taskChanges.Title;
            taskToUpdate.Description = taskChanges.Description;
            taskToUpdate.Due_date = taskChanges.Due_date;
            taskToUpdate.status = taskChanges.status;
            taskToUpdate.Priority = taskChanges.Priority;
            // Update other properties as needed

            dbContext.SaveChanges();
            return taskToUpdate;
        }


        public Tasks Delete(int id)
        {    
            var task = dbContext.Tasks.Find(id);
            if (task != null)
            {
                dbContext.Tasks.Remove(task);
                dbContext.SaveChanges();
            }
            return task;
        }

        public List<Tasks> GetTasksDueWithin48Hours()
        {
            // Implement the logic to retrieve tasks due within 48 hours for the specified user
            // You can interact with your data storage or repository here
            var now = DateTime.Now;
            var dueWithin48Hours = new List<Tasks>();

            List<Tasks> allTasks = dbContext.Tasks.ToList();

            // Example logic to retrieve tasks due within 48 hours
            foreach (var task in allTasks) // Replace with actual task retrieval logic
            {
                if (task.Due_date > now && task.Due_date <= now.AddHours(48))
                {
                    dueWithin48Hours.Add(task);
                }
            }

            return dueWithin48Hours;
        }

        public List<Tasks> GetCompletedTasks()
        {
            // Implement the logic to retrieve completed tasks for the specified user
            // You can interact with your data storage or repository here

            return dbContext.Tasks
                .Where(task => task.status == Status.Completed)
                .ToList();
        }

    }
}
