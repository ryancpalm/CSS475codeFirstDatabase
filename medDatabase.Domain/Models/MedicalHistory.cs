using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class MedicalHistory : IHasPatient, IHasIllness
    {
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
        public int IllnessId { get; set; }

        public int GetIllnessId()
        {
            return IllnessId;
        }

        [Required]
        public virtual Illness Illness { get; set; }

        public void SetIllness(Illness illness)
        {
            Illness = illness;
        }

        [Required]
        public DateTime DiagnosisDate { get; set; }

        [Required]
        public DateTime LastVisitDate { get; set; }
    }
}
