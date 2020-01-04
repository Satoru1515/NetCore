using JonaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonaDemo.Services
{
    public class UserRepository : IUserRepository 
    {
        private List<User> Users { get; set; }

        private User userLogged { get; set; }

         


        public UserRepository()
        {
            this.Users = new List<User>();
            this.userLogged = new User(); 

            User userMaster = new User();

            userMaster.Name = "Satoru";
            userMaster.LastName = "Yano Romero";
            userMaster.Email = "syano@gmail.com";
            userMaster.Password ="123";

            this.AddUser(userMaster);
            userLogged = userMaster;
           
        }

        public User GetUserLogged()
        {
            return this.userLogged;
        }
        public void SetUserLogged(User user)
        {
            this.userLogged = user;
        }

        public User AddUser(User user)
        {
           this.Users.Add(user);

            return user;
        }

        public User EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
         
            
           return this.Users.ToList();
           
        }

        public User GetUser(int Id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email, string password)
        {
            var user = this.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && u.Password.ToLower() == password.ToLower());

            return user;
        }

       
    }
}
