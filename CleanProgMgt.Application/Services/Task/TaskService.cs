using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Domain;
using CleanProgMgt.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.Task
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository tasksRepository;

        //Constructor dependency injection

        public TasksService(ITasksRepository tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }

        public Tasks CreateTask(Tasks task)
        {
            var Task = tasksRepository.CreateTask(task);
            return Task;
        }


        public IEnumerable<Tasks> GetAllTasks()
        {
            var tasks = tasksRepository.GetAllTasks();

            return tasks;
        }

        public Tasks GetTaskById(long? id)
        {
            var task = tasksRepository.GetTaskById(id);
            return task;
        }

        public Tasks Update(int id, TaskCreateDto taskChanges)
        {
            var Task = tasksRepository.Update(id,taskChanges);
            return Task;
        }
        public Tasks Delete(int id)
        {
            var Task = tasksRepository.Delete(id);
            return Task;
        }
        public List<Tasks> GetTasksDueWithin48Hours()
        {
            return tasksRepository.GetTasksDueWithin48Hours();
        }

        public List<Tasks> GetCompletedTasks()
        {
            return tasksRepository.GetCompletedTasks();
        }

        public List<TaskReadDto> GetTasksByStatusOrPriority(string status, string priority)
        {
            return tasksRepository.GetTasksByStatusOrPriority(status,priority);
        }

        public List<TaskReadDto> GetTasksDueThisWeek()
        {
            return tasksRepository.GetTasksDueThisWeek();
        }

        public bool ChangeTaskStatus(string id, string status)
        {
           return tasksRepository.ChangeTaskStatus(id, status);
        }
    }
}
