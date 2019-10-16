using AngApi.DAL.Model;
using AngApi.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngApi.BLL
{
    public interface IUser
    {
        User UpsertUser(User user);
        IEnumerable<User> GetUsers();
        bool DeleteUser(long userId);
        User GetUser(long Id);
    }
    public class BLUser : IUser
    {
        private readonly IUnitOfWork _uow;

        public BLUser(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        public bool DeleteUser(long userId)
        {
            _uow.User.DeleteUser(userId);
            _uow.Complete();
            return true;
        }

        public User GetUser(long Id)
        {
            if (Id <= default(long))
                throw new ArgumentException("Invalid id");

            return _uow.User.GetUser(Id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _uow.User.GetUsers();
        }

        public User UpsertUser(User user)
        {
            if (user == null)
                throw new ArgumentException("Invalid user");

            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentException("Invalid user name");

            var _user = _uow.User.GetUser(user.Id);
            if (_user == null)
            {
                _user = new User
                {
                    Name = user.Name
                };
                _uow.User.AddUser(_user);
            }
            else
            {
                _user.Name = user.Name;
            }

            _uow.Complete();

            return _user;
        }
    }
}
