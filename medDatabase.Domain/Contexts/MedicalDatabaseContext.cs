using System.Data.Entity;
using medDatabase.Domain.Models;
using medDatabase.Web;

namespace medDatabase.Domain.Contexts
{
    public class MedicalDatabaseContext : DbContext
    {
        private readonly ConfigProvider _configProvider;

        public virtual DbSet<Employee> Employee { get; set; }

        public MedicalDatabaseContext()
        {
            _configProvider = new ConfigProvider();
            SetConnectionStringForMedicalDatabase();
            // TODO: Correct mockaroo data that needs custom lists and date separation
            // TODO: Configure composite keys, possibly primary keys to be safe.
        }

        private void SetConnectionStringForMedicalDatabase()
        {
            var medicalDatabaseConnectionStringSettings = _configProvider.GetMedicalDatabaseConnectionStringSettings();
            var medicalDtabaseConnectionString = medicalDatabaseConnectionStringSettings.ConnectionString;
            this.Database.Connection.ConnectionString = medicalDtabaseConnectionString;
        }
    }
}
