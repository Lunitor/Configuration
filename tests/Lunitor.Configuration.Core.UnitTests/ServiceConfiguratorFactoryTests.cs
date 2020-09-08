using Lunitor.Configuration.Core.Model;
using System;
using Xunit;

namespace Lunitor.Configuration.Core.UnitTests
{
    public class ServiceConfiguratorFactoryTests
    {
        private ServiceConfiguratorFactory _serviceConfiguratorFactory;

        public ServiceConfiguratorFactoryTests()
        {
            _serviceConfiguratorFactory = new ServiceConfiguratorFactory();
        }

        [Fact]
        public void GetConfiguratorThrowsArgumentNullExceptionIfServiceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _serviceConfiguratorFactory.GetConfigurator(null));
        }
    }
}
