using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name);
        }
    }
}