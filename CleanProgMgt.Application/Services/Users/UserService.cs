using CleanProgMgt.Application.Dtos;
using CleanProgMgt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProgMgt.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            return userRepository.CreateUser(user);
        }

        public User Delete(int id)
        {
            return userRepository.Delete(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User GetUserById(long? id)
        {
            return userRepository.GetUserById(id);
        }

        public User Update(int id, UserCreateDto userChanges)
        {
            return userRepository.Update(id,userChanges);
        }
    }
}
