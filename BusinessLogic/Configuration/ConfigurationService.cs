using System.Collections.Generic;
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
        
        private Dictionary<string, string> _connectionStrings = new Dictionary<string, string>();
        
        public string ConnectionString(string name)
        {
            if ( _connectionStrings.TryGetValue( name, out string result ) )
            {
                return result;
            }
            
            var connectionString = _configuration.GetConnectionString(name);
            _connectionStrings.Add(name, connectionString);

            return connectionString;
        }
    }
}