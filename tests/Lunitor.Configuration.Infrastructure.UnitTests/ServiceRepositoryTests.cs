using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Lunitor.Configuration.Infrastructure.UnitTests
{
    public class ServiceRepositoryTests
    {
        private ServiceRepository _serviceRepository;
        private IConfiguration _configuration;

        private const string ServicesConfiguration = @"
        {
            ""Services"": [
                {
                    ""Name"": ""Lunitor\\AutomaticShutDown"",
                    ""ConfiguratorTypeName"": ""WindowsTaskServiceConfigurator""
                },
                {
                    ""Name"": ""Lunitor\\Test"",
                    ""ConfiguratorTypeName"": ""WindowsTaskServiceConfigurator""
                }
            ]
        }";
        private const string EmptyConfiguration = "{}";
        private const string EmptyServicesConfiguration = @"
        {
            ""Services"" : []
        }";


        public ServiceRepositoryTests()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes(ServicesConfiguration)));
            _configuration = configurationBuilder.Build();

            _serviceRepository = new ServiceRepository(_configuration);
        }

        [Fact]
        public void GetAllReturnsEmptyListIfThereIsNoServiceSectionInConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes(EmptyConfiguration)));
            _configuration = configurationBuilder.Build();

            var serviceRepository = new ServiceRepository(_configuration);
            var services = serviceRepository.GetAll();

            Assert.NotNull(services);
            Assert.Empty(services);
        }

        [Fact]
        public void GetAllReturnsEmptyListIfServicesSectionIsEmptyInConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes(EmptyServicesConfiguration)));
            _configuration = configurationBuilder.Build();

            var serviceRepository = new ServiceRepository(_configuration);

            var services = serviceRepository.GetAll();

            Assert.NotNull(services);
            Assert.Empty(services);
        }

        [Fact]
        public void GetAllReturnsAllServicesFromConfiguration()
        {
            var services = _serviceRepository.GetAll();

            Assert.NotNull(services);
            Assert.NotEmpty(services);
            Assert.Equal(2, services.Count());
        }
    }
}