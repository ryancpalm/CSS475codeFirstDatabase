using System;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Models;

namespace medDatabase.Domain.Mockaroo.Models
{
    public class MockarooMedicalHistory : IMockarooConvertible<MedicalHistory>
    {
        public int PatientId { get; set; }

        public int IllnessId { get; set; }

        public DateTime DiagnosisDate { get; set; }

        public DateTime LastVisitDate { get; set; }

        public MedicalHistory Convert()
        {
            var medicalHistory = new MedicalHistory
            {
                PatientId = PatientId,
                Patient = new Patient { Id = PatientId },
                IllnessId = IllnessId,
                Illness = new Illness { Id = IllnessId },
                DiagnosisDate = DiagnosisDate,
                LastVisitDate = LastVisitDate.Date
            };
            return medicalHistory;
        }
    }
}
