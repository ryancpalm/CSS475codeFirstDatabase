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
            // TODO: Correct populated objects to use the corresponding object in the appropriate collection
            // TODO: Add virtual specifier to foreign objects in models w/ foreign keys
            // TODO: Add doctor and nurse mock data
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetupEmployeeKeys(modelBuilder);
            SetupNurseKeys(modelBuilder);
            SetupDoctorKeys(modelBuilder);
            SetupAddressKeys(modelBuilder);
            SetupPrescriptionKeys(modelBuilder);
            SetupAppointmentKeys(modelBuilder);
            SetupMedicalHistoryKeys(modelBuilder);
        }

        private static void SetupEmployeeKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => new {e.Id});
        }

        private static void SetupNurseKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nurse>()
                .HasRequired(n => n.Employee)
                .WithMany().HasForeignKey(n => n.EmployeeId);
            modelBuilder.Entity<Nurse>()
                .HasRequired(n => n.NurseSpecialty)
                .WithMany().HasForeignKey(n => n.NurseSpecialtyId);
        }

        private static void SetupDoctorKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasRequired(n => n.Employee)
                .WithMany().HasForeignKey(n => n.EmployeeId);
            modelBuilder.Entity<Doctor>()
                .HasRequired(n => n.DoctorSpecialty)
                .WithMany().HasForeignKey(n => n.DoctorSpecialtyId);
        }

        private static void SetupAddressKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasRequired(a => a.Patient)
                .WithMany().HasForeignKey(a => a.PatientId);
        }

        private static void SetupPrescriptionKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>()
                .HasRequired(p => p.Patient)
                .WithMany().HasForeignKey(p => p.PatientId);
            modelBuilder.Entity<Prescription>()
                .HasRequired(p => p.Doctor)
                .WithMany().HasForeignKey(p => p.DoctorId);
            modelBuilder.Entity<Prescription>()
                .HasRequired(p => p.Medication)
                .WithMany().HasForeignKey(p => p.MedicationId);
        }

        private static void SetupAppointmentKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Patient)
                .WithMany().HasForeignKey(a => a.PatientId);
            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Doctor)
                .WithMany().HasForeignKey(a => a.DoctorId);
        }

        private static void SetupMedicalHistoryKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalHistory>()
                .HasRequired(h => h.Patient)
                .WithMany().HasForeignKey(h => h.PatientId);
            modelBuilder.Entity<MedicalHistory>()
                .HasRequired(h => h.Illness)
                .WithMany().HasForeignKey(h => h.IllnessId);
        }

        private void SetConnectionStringForMedicalDatabase()
        {
            var medicalDatabaseConnectionStringSettings = _configProvider.GetMedicalDatabaseConnectionStringSettings();
            var medicalDtabaseConnectionString = medicalDatabaseConnectionStringSettings.ConnectionString;
            this.Database.Connection.ConnectionString = medicalDtabaseConnectionString;
        }
    }
}
