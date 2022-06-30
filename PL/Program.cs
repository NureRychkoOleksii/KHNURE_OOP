using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PL.StartupMethods;

namespace PL
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