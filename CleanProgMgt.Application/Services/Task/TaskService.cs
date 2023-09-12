using CleanProgMgt.Domain;
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

        public Tasks Update(Tasks taskChanges)
        {
            var Task = tasksRepository.Update(taskChanges);
            return Task;
        }
        public Tasks Delete(int id)
        {
            var Task = tasksRepository.Delete(id);
            return Task;
        }
        public List<Tasks> GetTasksDueWithin48Hours(int userId)
        {
            return tasksRepository.GetTasksDueWithin48Hours(userId);
        }

    }
}
