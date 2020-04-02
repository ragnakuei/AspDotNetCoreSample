using System.Collections.Generic;
using System.Configuration;

namespace BusinessLogic.Configuration
{
    /// <summary>
    /// 透過 ConfigurationManager 讀取組態檔
    /// </summary>
    public class ConfigurationManagerService : IConfigurationService
    {
        public ConfigurationManagerService()
        {
        }
        
        private Dictionary<string, string> _connectionStrings = new Dictionary<string, string>();
        
        public string ConnectionString(string name)
        {
            if ( _connectionStrings.TryGetValue( name, out string result ) )
            {
                return result;
            }
            
            var connectionString = ConfigurationManager.ConnectionStrings[name]?.ToString();
            _connectionStrings.Add(name, connectionString);

            return connectionString;
        }
    }
}