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
        List<TaskReadDto> GetTasksByStatusOrPriority(string status, string priority);
        List<TaskReadDto> GetTasksDueThisWeek();
        List<Tasks> GetTasksDueBetweenDates(DateTime startDate, DateTime endDate);
        bool ChangeTaskStatus(string id, string status);

    }
}
