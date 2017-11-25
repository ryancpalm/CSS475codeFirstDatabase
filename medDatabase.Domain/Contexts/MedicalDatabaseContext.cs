using System.Data.Entity;
using medDatabase.Domain.Models;
using medDatabase.Web;

namespace medDatabase.Domain.Contexts
{
    public class MedicalDatabaseContext : DbContext
    {
        private readonly ConfigProvider _configProvider;

        public MedicalDatabaseContext()
        {
            _configProvider = new ConfigProvider();
            var medicalDatabaseConnectionStringKey = _configProvider.GetMedicalDatabaseConnectionStringSettings();
        }

        public virtual DbSet<Employee> Employee { get; set; }
    }
}
