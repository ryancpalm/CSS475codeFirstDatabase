using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace medDatabase.Web
{
    public class ConfigProvider
    {
        public const string MedicalDatabaseConnectionStringKey = "MedicalDatabase";

        private readonly ConnectionStringSettingsCollection _connectionStrings = ConfigurationManager.ConnectionStrings;

        public ConnectionStringSettings GetMedicalDatabaseConnectionStringSettings()
        {
            var medDbConnectionStringSettings = _connectionStrings[MedicalDatabaseConnectionStringKey];
            return medDbConnectionStringSettings;
        }
    }
}