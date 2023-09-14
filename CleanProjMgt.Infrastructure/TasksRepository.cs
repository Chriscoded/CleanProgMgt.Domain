using AutoMapper;
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
        private readonly IMapper mapper;

        public TasksRepository(TasksDbContext dbContext, IMapper mapper)
        {
            this.mapper = mapper;
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
            taskToUpdate.ProjectId = taskChanges.ProjectId;
            taskToUpdate.UserId = taskChanges.UserId;
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
                if (task.Due_date > now && task.Due_date <= now.AddMinutes(48) && task.status == Status.Completed)
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

        public List<TaskReadDto> GetTasksByStatusOrPriority(string status, string priority)
        {
             Status.TryParse(status, out Status taskStatus);
            Priority.TryParse(priority, out Priority taskPriority);

            // Query tasks based on status and priority
            var tasksQuery = GetAllTasks();

            if (!string.IsNullOrEmpty(status))
            {
                tasksQuery = tasksQuery.Where(task => task.status == taskStatus);
            }

            if (!string.IsNullOrEmpty(priority))
            {
                tasksQuery = tasksQuery.Where(task => task.Priority == taskPriority);
            }

            var allTask = tasksQuery.ToList();
            var taskDtos = mapper.Map<List<TaskReadDto>>(allTask);

            return taskDtos;

        }

        public List<TaskReadDto> GetTasksDueThisWeek()
        {
            DateTime today = DateTime.Today;
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
            DateTime startOfWeek = today.AddDays(-daysUntilSunday);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // Query tasks due within the current week
            var tasks = GetTasksDueBetweenDates(startOfWeek, endOfWeek);

            var taskDtos = mapper.Map<List<TaskReadDto>>(tasks);

            return taskDtos;
        }

        public List<Tasks> GetTasksDueBetweenDates(DateTime startDate, DateTime endDate)
        {
             var tasks = dbContext.Tasks
                .Where(task => task.Due_date >= startDate && task.Due_date <= endDate)
                .ToList();

            return tasks;
        }

        public bool ChangeTaskStatus(string id, string status)
        {
            if (!Status.TryParse(status, out Status newStatus))
            {
                // Invalid status provided
                return false;
            }

            if (!int.TryParse(id, out int taskId))
            {
                // Invalid task ID provided
                return false;
            }

            var task = GetTaskById(taskId);

            if (task == null)
            {
                // Task with the specified ID was not found
                return false;
            }

            task.status = newStatus;
            // task.LastStatusChangeDate = DateTime.UtcNow; // Optionally, update the last status change date
            // var newtask = mapper.Map<TaskCreateDto>(task);
            var taskCreateDto = new TaskCreateDto
            {
                Title = task.Title,
                Description = task.Description,
                Due_date = task.Due_date,
                Priority = task.Priority,
                status = task.status,
                ProjectId = task.ProjectId,
                UserId = task.UserId
                // Include other properties as needed
            };

            try
            {
                Update(taskId, taskCreateDto); // Implement this method in your repository to update the task
                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                return false;
            }
        }
    }
}
