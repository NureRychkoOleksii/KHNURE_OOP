using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PL.StartupMethods;

namespace PL
{
    class Program
    {
        static async Task Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            await serviceProvider.GetService<App>().Start();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddScoped<App>();
            services.AddScoped<Startup>();
            BLL.DependencyRegistrar.ConfigureServices(services);
        }
    }
}