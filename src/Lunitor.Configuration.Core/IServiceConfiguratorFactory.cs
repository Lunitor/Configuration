using Lunitor.Configuration.Core.Model;

namespace Lunitor.Configuration.Core
{
    public interface IServiceConfiguratorFactory
    {
        IServiceConfigurator GetConfigurator(Service service);
    }
}