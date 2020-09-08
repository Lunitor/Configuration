using Ardalis.ApiEndpoints;
using Ardalis.GuardClauses;
using Lunitor.Configuration.Core;
using Lunitor.Configuration.Core.Model;
using Lunitor.Configuration.Web.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Lunitor.Configuration.Web.Server.Endpoints
{
    public class GetAllServices : BaseEndpoint<GetAllServicesResult>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceConfiguratorFactory _serviceConfiguratorFactory;

        public GetAllServices(IServiceRepository serviceRepository, IServiceConfiguratorFactory serviceConfiguratorFactory)
        {
            Guard.Against.Null(serviceRepository, nameof(serviceRepository));
            Guard.Against.Null(serviceConfiguratorFactory, nameof(serviceConfiguratorFactory));

            _serviceRepository = serviceRepository;
            _serviceConfiguratorFactory = serviceConfiguratorFactory;
        }

        [HttpGet("services")]
        public override ActionResult<GetAllServicesResult> Handle()
        {
            var services = _serviceRepository.GetAll();

            var response = new GetAllServicesResult
            {
                Services = Map(services)
            };

            return Ok(response);
        }

        private IEnumerable<ServiceDto> Map(IEnumerable<Service> services)
        {
            return services.Select(s => new ServiceDto
                            {
                                Name = s.Name,
                                Status = GetServiceStatus(s)
                            });
        }

        private ServiceStatus GetServiceStatus(Service s)
        {
            return _serviceConfiguratorFactory.GetConfigurator(s).GetStatus(s);
        }
    }
}
