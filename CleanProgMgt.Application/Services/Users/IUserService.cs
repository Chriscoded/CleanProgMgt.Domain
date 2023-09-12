using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.Users
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User CreateUser(User user);

        User GetUserById(long? id);
        User Update(User userChanges);
        User Delete(int id);
    }
}
