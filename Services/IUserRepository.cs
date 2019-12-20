using JonaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonaDemo.Services
{
    public interface IUserRepository
    {
        User AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUser(int Id);
        User GetUser(string email, string passwod);
        User EditUser(User user);
        User GetUserLogged();
        void SetUserLogged(User user);
    }
}
