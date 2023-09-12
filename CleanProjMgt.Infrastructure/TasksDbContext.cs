using CleanProgMgt.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProjMgt.Infrastructure
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many (Tasks and Projects)
            modelBuilder.Entity<Tasks>()
                 .HasOne<Project>(s => s.Project)
                 .WithMany(r => r.Tasks)
                 .HasForeignKey(s => s.ProjectId);

            // One to Many (Tasks and User)
            modelBuilder.Entity<Tasks>()
                 .HasOne<User>(s => s.User)
                 .WithMany(r => r.Tasks)
                 .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Notification>()
                .HasOne<User>(s => s.User)
                .WithMany(r => r.Notifications)
                .HasForeignKey(s => s.UserId);
        }


        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notification { get; set; }

    }
}
