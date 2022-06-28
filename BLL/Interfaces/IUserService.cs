using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        User? GetUserById(int id);
        IEnumerable<User> GetUsers();

        void UpdateUser(User user, int id);
    }
}
