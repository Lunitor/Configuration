using Lunitor.Configuration.Core.Model;

namespace Lunitor.Configuration.Core
{
    public interface IServiceConfigurator
    {
        void Start(Service service);
        void Stop(Service service);
        ServiceStatus GetStatus(Service service);
    }
}