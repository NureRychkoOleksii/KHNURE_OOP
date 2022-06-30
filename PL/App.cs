using System.Threading.Tasks;
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
