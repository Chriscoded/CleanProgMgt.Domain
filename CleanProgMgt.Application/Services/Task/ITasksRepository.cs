using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.Task
{
    public interface ITasksRepository
    {
        IEnumerable<Tasks> GetAllTasks();
        Tasks CreateTask(Tasks task);

        Tasks GetTaskById(long? id);
        Tasks Update(int id, TaskCreateDto taskChanges);
        Tasks Delete(int id);
        List<Tasks> GetTasksDueWithin48Hours();
        List<Tasks> GetCompletedTasks();

    }
}
