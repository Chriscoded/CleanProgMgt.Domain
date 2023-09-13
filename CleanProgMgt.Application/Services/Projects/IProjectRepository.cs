using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.Projects
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects();
        Project CreateProject(Project project);

        Project GetProjectById(long? id);
        Project Update(int id, ProjectCreateDto projectChanges);
        Project Delete(int id);
    }
}
