using Lunitor.Configuration.Web.Server.Dto;
using System.Collections.Generic;

namespace Lunitor.Configuration.Web.Server.Endpoints
{
    public class GetAllServicesResult
    {
        public IEnumerable<ServiceDto> Services { get; set; }
    }
}