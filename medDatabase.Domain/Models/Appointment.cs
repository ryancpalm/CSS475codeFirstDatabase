using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Appointment : IMedicalDatabaseModel, IHasPatient, IHasEmployee
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

        public void SetEmployee(Employee empoyee)
        {
            Doctor = empoyee;
        }

        [Required]
        public DateTime DateAndTime { get; set; }
    }
}
