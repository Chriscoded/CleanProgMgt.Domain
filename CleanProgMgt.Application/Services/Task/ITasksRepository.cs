﻿using CleanProgMgt.Domain;
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
        Tasks Update(Tasks taskChanges);
        Tasks Delete(int id);
        List<Tasks> GetTasksDueWithin48Hours(int userId);

    }
}