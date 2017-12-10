using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace medDatabase.Web.Contexts
{
    public class MedicalDbConfiguration : DbConfiguration
    {
        public MedicalDbConfiguration()
        {
            SetExecutionStrategy(
                "System.Data.SqlClient",
                () => new SqlAzureExecutionStrategy(1, TimeSpan.FromSeconds(60)));
        }
    }
}