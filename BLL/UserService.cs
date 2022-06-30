using BLL.Interfaces;
using Core.Models;
using DAL.Interfaces;
using DAL.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly Repository<User> _repository = new Repository<User>();
        private string _path = "..\\..\\..\\..\\DAL\\JSON\\Users.json";

        public void AddUser(User user)
        {
            _repository.CreateObject(user, _path);
        }
        
        public User? GetUserById(int id)
        {
            return _repository.GetById(_path, id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _repository.GetAllAsync(_path);
        }

        public void UpdateUser(User user, int id)
        {
            var userGet = _repository.GetById(_path, id);
            _repository.DeleteObject(userGet, _path);
            _repository.CreateObject(user, _path);
        }
    }
}