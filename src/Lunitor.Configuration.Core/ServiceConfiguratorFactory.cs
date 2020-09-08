using Ardalis.GuardClauses;
using Lunitor.Configuration.Core.Model;
using System;

namespace Lunitor.Configuration.Core
{
    public class ServiceConfiguratorFactory : IServiceConfiguratorFactory
    {
        public IServiceConfigurator GetConfigurator(Service service)
        {
            Guard.Against.Null(service, nameof(service));

            return Activator.CreateInstance(service.ConfiguratorType) as IServiceConfigurator;
        }
    }
}
