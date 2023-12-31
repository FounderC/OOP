using КР.Models;

namespace КР.Repository.Base
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(string userName);
        void UpdateUser(User user);
    }
}