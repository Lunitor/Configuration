using Lunitor.Configuration.Core;
using Lunitor.Configuration.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceConfiguratorFactory, ServiceConfiguratorFactory>();
        }

        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
    }
}
