using BLL.Interfaces;
using Core.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private string _path = "..\\..\\..\\..\\DAL\\JSON\\Users.json";

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task AddUser(User user)
        {
            await _repository.CreateObject(user, _path);
        }
        
        public async Task<User?> GetUserById(int id)
        {
            return await _repository.GetById(_path, id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAllAsync(_path);
        }

        public async Task UpdateUser(User user, int id)
        {
            var userGet = await _repository.GetById(_path, id);
            await _repository.DeleteObject(userGet, _path);
            await _repository.CreateObject(user, _path);
        }
    }
}