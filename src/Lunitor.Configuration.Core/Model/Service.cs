using System;
using System.Linq;

namespace Lunitor.Configuration.Core.Model
{
    public class Service
    {
        public string Name { get; set; }

        private Type _configurationType;
        public Type ConfiguratorType
        {
            get => _configurationType;
            set
            {
                if (value.GetInterfaces().FirstOrDefault(i => i == typeof(IServiceConfigurator)) == null)
                    throw new ArgumentException($"{nameof(ConfiguratorType)} must implement {nameof(IServiceConfigurator)}");

                _configurationType = value;
            }
        }
    }
}
