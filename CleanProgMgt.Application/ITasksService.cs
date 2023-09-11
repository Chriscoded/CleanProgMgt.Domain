using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application
{
    public interface ITasksService
    {
        List<Tasks> GetAllTasks();
    }
}
