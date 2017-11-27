using System;
using medDatabase.Domain.Models;
using medDatabase.Populater.Interfaces;

namespace medDatabase.Populater.Mockaroo.Models
{
    public class MockarooPrescription : IMockarooConvertible<Prescription>
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int MedicationId { get; set; }

        public int Refills { get; set; }

        public int Quantity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Prescription Convert()
        {
            var prescription = new Prescription
            {
                Id = Id,
                PatientId = PatientId,
                Patient = new Patient { Id = PatientId },
                DoctorId = DoctorId,
                Doctor = new Employee { Id = DoctorId },
                MedicationId = MedicationId,
                Medication = new Medication { Id = MedicationId },
                Quantity = Quantity,
                Refills = Refills,
                StartDate = StartDate,
                EndDate = EndDate
            };
            return prescription;
        }
    }
}
