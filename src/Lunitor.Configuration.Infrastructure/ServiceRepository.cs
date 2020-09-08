using Ardalis.GuardClauses;
using Lunitor.Configuration.Core;
using Lunitor.Configuration.Core.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lunitor.Configuration.Infrastructure
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IConfiguration _configuration;

        public ServiceRepository(IConfiguration configuration)
        {
            Guard.Against.Null(configuration, nameof(configuration));

            _configuration = configuration;
        }

        public IEnumerable<Service> GetAll()
        {
            var servicesSection = _configuration.GetSection("Services");

            if (servicesSection.Exists())
                return servicesSection
                    .Get<List<ServiceConfigurationDto>>()
                    .Select(dto => Map(dto));
            else
                return new List<Service>();
        }

        private static Service Map(ServiceConfigurationDto dto)
        {
            return new Service
            {
                Name = dto.Name,
                ConfiguratorType = Assembly.GetExecutingAssembly()
                                        .GetTypes()
                                        .First(t => t.Name == dto.ConfiguratorTypeName)
            };
        }
    }
}
