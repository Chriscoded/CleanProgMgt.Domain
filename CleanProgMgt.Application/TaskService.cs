using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository tasksRepository;

        //Constructor dependency injection

        public TasksService(ITasksRepository tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }

        public List<Tasks> GetAllTasks()
        {
            var tasks = tasksRepository.GetAllTasks();

            return tasks;
        }
    }
}
