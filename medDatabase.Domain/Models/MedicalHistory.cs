using System;
using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class MedicalHistory
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
