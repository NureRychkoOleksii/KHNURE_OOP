using BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class DependencyRegistrar
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            DAL.DependencyRegistrar.ConfigureServices(services);
        }
    }
}
