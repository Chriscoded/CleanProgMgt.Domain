using CleanProgMgt.Application.Services.Users;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProjMgt.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksDbContext dbContext;

        public UserRepository(TasksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public User CreateUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var user = dbContext.Users.Find(id);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return dbContext.Users;
        }

        public User GetUserById(long? id)
        {
            var data = dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (data == null)
                return null;
            else return data;
        }

        public User Update(User userChanges)
        {
            var user = dbContext.Users.Attach(userChanges);
            //user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return userChanges;
        }
    }
}
