using System.Threading.Tasks;
using BLL.Interfaces;
using PL.StartupMethods;

namespace PL
{
    public class App 
    {
        private readonly Startup _startup = new Startup();


        public void Start()
        {
            _startup.StartGame();
        }
    }
}
