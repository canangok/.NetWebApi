using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Database;
using WebApi.Entities;

namespace WebApi.DAL.Managements
{
    public class UserManagement
    {
        private ProjectContext database;

        public UserManagement()
        {
            database = new ProjectContext();
        }

        public List<User> GetUsers()
        {
            return database.User.ToList();
        }

        public User GetUser(int id)
        {
            return database.User.FirstOrDefault(i => i.Id == id);
        }

        public User AddUser(User user)
        {

            using (var databaseContext = new ProjectContext())
            {
                databaseContext.User.Add(user);
                databaseContext.SaveChanges();
            }

            return user;
        }

        public bool UpdateUser(User user)
        {
            using (var databaseContext = new ProjectContext())
            {
                databaseContext.Entry(user).State = EntityState.Modified;
                return databaseContext.SaveChanges() > 0;
            }
        }

        public bool ChangeUser(User userOld, User userNew)
        {
            using (var databaseContext = new ProjectContext())
            {
                databaseContext.Entry(userOld).CurrentValues.SetValues(userNew);
                return databaseContext.SaveChanges() > 0;
            }
        }

        public bool RemoveUser(int id)
        {
            var user = GetUser(id);
            using (var databaseContext = new ProjectContext())
            {
                database.User.Remove(user);
                return databaseContext.SaveChanges() > 0;
            }
        }

        public bool RemoveUser(User user)
        {
            using (var databaseContext = new ProjectContext())
            {
                database.User.Remove(user);
                return databaseContext.SaveChanges() > 0;
            }
        }
    }
}
