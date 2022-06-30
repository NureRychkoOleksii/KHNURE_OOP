using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Console.StartupMethods;

namespace Console
{
    class Program
    {
        static void Main()
        {
            App app = new App();
            app.Start();
        }
    }
}