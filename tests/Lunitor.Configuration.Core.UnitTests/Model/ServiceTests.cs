using Lunitor.Configuration.Core.Model;
using System;
using Xunit;

namespace Lunitor.Configuration.Core.UnitTests.Model
{
    public class ServiceTests
    {
        class TestServiceConfigurator { }

        [Fact]
        public void SetConfiguratorTypeThrowsArgumentExceptionIfAssignedValueNotImplementsIServiceConfigurator()
        {
            var service = new Service
            {
                Name = "test"
            };

            Assert.Throws<ArgumentException>(() => service.ConfiguratorType = typeof(TestServiceConfigurator));
        }
    }
}
