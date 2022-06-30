using System.Threading.Tasks;
using Console.StartupMethods;

namespace Console
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
