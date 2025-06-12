using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EventDbContext _context;

        public UserRepository(EventDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserInfo user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(UserInfo user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(string email)
        {
            var user = _context.Users.Find(email);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public UserInfo GetUserByEmail(string email)
        {
            return _context.Users.Find(email);
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
