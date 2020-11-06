using Cassete_API.Models;
using Cassete_API.Models.User;
using Cassete_API.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Cassete_API.Repository.Services
{
    public class UserService : IUserService
    {
        private ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public UserModel Search(string subString)
        {
            return _context.Users.FirstOrDefault(u => u.Login.Contains(subString));
        }

        public void Add(UserModel user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);

            _context.Users.Remove(user);
            _context.SaveChangesAsync();
        }

        public UserModel Get(int id)
        {
            var User = (from user
                           in _context.Users
                        where user.Id == id
                        select user).FirstOrDefault();

            return User;
        }

        public List<UserModel> GetAll()
        {
            var allUsers = (from user
                            in _context.Users
                            select user).ToList();

            return allUsers;
        }

        public void Update(UserModel user)
        {
            if (_context.Users.Any(_user => _user.Id == user.Id))
            {
                _context.Update(user);
                _context.SaveChangesAsync();
            }
        }
    }
}
