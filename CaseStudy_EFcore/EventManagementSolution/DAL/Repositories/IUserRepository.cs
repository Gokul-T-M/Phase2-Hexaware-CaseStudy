using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IUserRepository
    {
        void AddUser(UserInfo user);
        void UpdateUser(UserInfo user);
        void DeleteUser(string email);
        UserInfo GetUserByEmail(string email);
        IEnumerable<UserInfo> GetAllUsers();
    }
}
