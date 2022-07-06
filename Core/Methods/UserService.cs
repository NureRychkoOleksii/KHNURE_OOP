using Core.Models;
using DAL.Services;
using System.Collections.Generic;
using System.Linq;

namespace Core.Methods
{
    public class UserService
    {
        private readonly Repository<User> _repository = new Repository<User>();
        private string _path = "Users.json";

        public void AddUser(User user)
        {
            _repository.CreateObject(user, _path);
        }

        public void AddNewUser(User user)
        {
            _repository.CreateFirstObject(user, _path);
        }

        public User? GetUserById(int id)
        {
            return _repository.GetById(_path, id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _repository.GetAll(_path);
        }

        public void UpdateUser(ref User user, int id)
        {
            var userGet = _repository.GetById(_path, id);
            _repository.DeleteObject(userGet, _path);
            _repository.CreateObject(user, _path);
            user.Id = GetUserByName(user.Name).Id;  
        }

        public User GetUserByName(string name)
        {
            var res = GetUsers();
            return res.Where(user => user.Name == name).FirstOrDefault();
        }

    }
}
