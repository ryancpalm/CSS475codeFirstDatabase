using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class MedicalHistory : IMedicalDatabaseModel
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public virtual Patient Patient { get; set; }

        [Required]
        public int IllnessId { get; set; }

        [Required]
        public virtual Illness Illness { get; set; }

        [Required]
        public DateTime DiagnosisDate { get; set; }

        [Required]
        public DateTime LastVisitDate { get; set; }
    }
}
