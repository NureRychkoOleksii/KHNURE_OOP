using System.Threading.Tasks;
using BLL.Interfaces;
using PL.StartupMethods;

namespace PL
{
    public class App 
    {
        private readonly Startup _startup;
        private readonly IUserService _userService;

        public App(IUserService service, Startup startup)
        {
            _startup = startup;
            _userService = service;
        }

        public async Task Start()
        {
            await _startup.StartGame();
        }
    }
}
