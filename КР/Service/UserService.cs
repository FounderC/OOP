using КР.Repository.Base;
using System;
using КР.Models;

namespace КР.Service
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(string userName, string password)
        {
            var existingUser = _userRepository.GetUser(userName);
            if (existingUser != null)
            {
                Console.WriteLine("Користувач з таким ім'ям вже існує. Будь ласка, виберіть інше ім'я.");
                return;
            }

            var user = new User { UserName = userName, Password = password, Balance = 0 };
            _userRepository.AddUser(user);
            Console.WriteLine($"Реєстрація користувача {userName} успішна!");
        }

        public User Login(string userName, string password)
        {
            var user = _userRepository.GetUser(userName);
            if (user != null && user.Password == password)
            {
                return user;
            }

            return null;
        }

        public void TopUpBalance(User user, decimal amount)
        {
            user.Balance += amount;
            UpdateUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
    }
}