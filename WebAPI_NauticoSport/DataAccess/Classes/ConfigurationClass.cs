using Microsoft.Extensions.Configuration;

namespace DataAccess.Classes
{
    internal class ConfigurationClass
    {
        private IConfiguration _configuration;

        #region Singleton
        private static ConfigurationClass _instance = new ConfigurationClass();

        private ConfigurationClass() { }

        public static ConfigurationClass Instance() {
            return _instance;
        }
        #endregion

        public void SetConfiguration(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string GetConnectionString(string connectionStringName) {
            return _configuration.GetConnectionString(connectionStringName);
        }

    }
}
