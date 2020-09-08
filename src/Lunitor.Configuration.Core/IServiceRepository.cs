using Lunitor.Configuration.Core.Model;
using System.Collections.Generic;

namespace Lunitor.Configuration.Core
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAll();
    }
}
