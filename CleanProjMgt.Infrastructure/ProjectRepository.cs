using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Application.Services.Projects;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            return dbContext.Project
              .Include(proj => proj.Tasks)
              .ToList();
        }

        public Project GetProjectById(long? id)
        {
            var data = dbContext.Project
                .Include(proj=> proj.Tasks)
                .FirstOrDefault(x => x.Id == id);
            if (data == null)
                return null;
            else return data;
        }

        public Project Update(int id, ProjectCreateDto projectChanges)
        {
            //user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var projectToUpdate = dbContext.Project.Find(id);

            if (projectToUpdate == null)
            {
                // Handle not found error, e.g., throw an exception
                return null;
            }

            // Update the task properties with values from the DTO
            projectToUpdate.Name = projectChanges.Name;
            projectToUpdate.Description = projectChanges.Description;
            
            // Update other properties as needed

            dbContext.SaveChanges();
            return projectToUpdate;
        }
    }
}
