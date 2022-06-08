using DAL.Interfaces;
using DAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyRegistrar
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISerializationWorker, SerializationWorker>();
        }
    }
}