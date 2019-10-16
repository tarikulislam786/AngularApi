using AngApi.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AngApi.DAL.Repositories
{
    public interface IUserRepository
    {
        int AddUser(User user);
        IEnumerable<User> GetUsers();
        bool DeleteUser(long userId);
        User GetUser(long Id);
        User GetUserByName(string UserName);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationContext _context;
        public UserRepository(AuthenticationContext context)
        {
            this._context = context;
        }
        public int AddUser(User user)
        {
           // int id;
            _context.Users.Add(user);
            _context.SaveChanges(); // needed to have returned last insert id
            return user.Id; // return last insert id
        }

        public bool DeleteUser(long userId)
        {
            var removed = false;
            User user = GetUser(userId);

            if (user != null)
            {
                removed = true;
                _context.Users.Remove(user);
            }

            return removed;
        }

        public User GetUser(long Id)
        {
            return _context.Users.Where(u => u.Id == Id).FirstOrDefault();
        }

        public User GetUserByName(string UserName)
        {
            return _context.Users.Where(u => u.Name == UserName).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }
    }
}
