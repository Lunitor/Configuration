using Lunitor.Configuration.Core;
using Lunitor.Configuration.Web.Server.Endpoints;
using Moq;
using System;
using Xunit;

namespace Lunitor.Configuration.Web.Server.UnitTests.Endpoints
{
    public class GetAllServicesTests
    {
        private Mock<IServiceRepository> _serviceRepositoryMock;
        private Mock<IServiceConfiguratorFactory> _serviceConfiguratorFactoryMock;

        public GetAllServicesTests()
        {
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _serviceConfiguratorFactoryMock = new Mock<IServiceConfiguratorFactory>();
        }

        [Fact]
        public void ConstructorThrowsArgumentNullExceptionIfIServiceRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new GetAllServices(null, _serviceConfiguratorFactoryMock.Object));
        }

        [Fact]
        public void ConstructorThrowsArgumentNullExceptionIfIServiceConfiguratorFactoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new GetAllServices(_serviceRepositoryMock.Object, null));
        }
    }
}
