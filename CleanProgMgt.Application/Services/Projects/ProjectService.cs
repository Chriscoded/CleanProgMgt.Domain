using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public Project CreateProject(Project project)
        {
            return projectRepository.CreateProject(project);
        }

        public Project Delete(int id)
        {
            return projectRepository.GetProjectById(id);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return projectRepository.GetAllProjects();
        }

        public Project GetProjectById(long? id)
        {
            return projectRepository.GetProjectById(id);
        }

        public Project Update(Project projectChanges)
        {
            return projectRepository.Update(projectChanges);
        }
    }
}
