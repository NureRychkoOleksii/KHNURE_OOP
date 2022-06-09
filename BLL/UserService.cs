using BLL.Interfaces;
using Core.Models;
using DAL.Interfaces;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        //private string _path = "..\\..\\..\\..\\..\\DAL\\JSON\\Users.json";
        private string _path = @"E:\git_repos\KH\DAL\JSON\Users.json";

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task AddUser(User user)
        {
            await _repository.CreateObject(user, _path);
        }
    }
}
