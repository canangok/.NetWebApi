using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Managements;
using WebApi.Entities;

namespace WebApi.Services
{
    public class UserService
    {
        private UserManagement userManagement;

        public UserService()
        {
            userManagement = new UserManagement();
        }

        public List<User> GetUsers() => userManagement.GetUsers();

        public User GetUser(int id)
        {
            return userManagement.GetUser(id);
        }

        public User AddUser(User user)
        {
            var newUser = userManagement.AddUser(user);
            return newUser;
        }

        public bool RemoveUser(int id)
        {
            return userManagement.RemoveUser(id);
        }

    }
}
