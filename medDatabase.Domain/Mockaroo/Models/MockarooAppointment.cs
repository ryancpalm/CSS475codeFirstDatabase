using System;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Models;

namespace medDatabase.Domain.Mockaroo.Models
{
    public class MockarooAppointment : IMockarooConvertible<Appointment>
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime DateAndTime { get; set; }

        public Appointment Convert()
        {
            var appointment = new Appointment
            {
                Id = Id,
                PatientId = PatientId,
                Patient = new Patient { Id = PatientId },
                DoctorId = DoctorId,
                Doctor = new Employee { Id = DoctorId },
                DateAndTime = DateAndTime
            };
            return appointment;
        }
    }
}
