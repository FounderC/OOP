using System.Collections.Generic;
using System.Linq;
using КР.Models;
using КР.Repository.Base;

namespace КР.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUser(string userName)
        {
            return _users.FirstOrDefault(u => u.UserName == userName);
        }

        public void UpdateUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Balance = user.Balance;
            }
        }
    }
}