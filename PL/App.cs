using System.Threading.Tasks;
using BLL.Interfaces;
using PL.StartupMethods;

namespace PL
{
    public class App 
    {
        private readonly Startup _startup;

        public App(Startup startup)
        {
            _startup = startup;
        }

        public async Task Start()
        {
            await _startup.StartGame();
        }
    }
}
