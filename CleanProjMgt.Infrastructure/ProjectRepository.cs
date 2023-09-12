using CleanProgMgt.Application.Services.Projects;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProjMgt.Infrastructure
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TasksDbContext dbContext;

        public ProjectRepository(TasksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Project CreateProject(Project project)
        {
            dbContext.Project.Add(project);
            dbContext.SaveChanges();
            return project;
        }

        public Project Delete(int id)
        {
            var project = dbContext.Project.Find(id);
            if (project != null)
            {
                dbContext.Project.Remove(project);
                dbContext.SaveChanges();
            }
            return project;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return dbContext.Project;
        }

        public Project GetProjectById(long? id)
        {
            var data = dbContext.Project.FirstOrDefault(x => x.Id == id);
            if (data == null)
                return null;
            else return data;
        }

        public Project Update(Project projectChanges)
        {
            var project = dbContext.Project.Attach(projectChanges);
            dbContext.Project.Update(projectChanges);
            //project.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return projectChanges;
        }
    }
}
