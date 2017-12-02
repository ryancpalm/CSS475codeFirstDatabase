using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Prescription : IMedicalDatabaseModel, IHasPatient, IHasEmployee, IHasMedication
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        public int GetPatientId()
        {
            return PatientId;
        }

        [Required]
        public virtual Patient Patient { get; set; }

        public void SetPatient(Patient patient)
        {
            Patient = patient;
        }

        [Required]
        public int DoctorId { get; set; }

        public int GetEmployeeId()
        {
            return DoctorId;
        }

        [Required]
        public virtual Employee Doctor { get; set; }

        public void SetEmployee(Employee employee)
        {
            Doctor = employee;
        }

        [Required]
        public int MedicationId { get; set; }

        public int GetMedicationId()
        {
            return MedicationId;
        }

        [Required]
        public virtual Medication Medication { get; set; }

        public void SetMedication(Medication medication)
        {
            Medication = medication;
        }

        [Required]
        public int Refills { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
