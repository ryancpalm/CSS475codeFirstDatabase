using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Prescription : IMedicalDatabaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public virtual Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public virtual Employee Doctor { get; set; }

        [Required]
        public int MedicationId { get; set; }

        [Required]
        public virtual Medication Medication { get; set; }

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
