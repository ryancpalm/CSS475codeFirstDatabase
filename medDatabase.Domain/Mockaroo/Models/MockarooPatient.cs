using System;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Models;

namespace medDatabase.Domain.Mockaroo.Models
{
    public class MockarooPatient : IMockarooConvertible<Patient>
    {
        public int Id { get; set; }

        public string Ssn { get; set; }

        public int RoomId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; }

        public Patient Convert()
        {
            var gender = Gender == "Male" ? Domain.Models.Gender.Male : Domain.Models.Gender.Female;
            var patient = new Patient
            {
                Gender = gender,
                Id = Id,
                Ssn = Ssn.Replace("-", string.Empty),
                AdmissionDate = AdmissionDate,
                DischargeDate = DischargeDate,
                Age = Age,
                FirstName = FirstName,
                LastName = LastName,
                RoomId = RoomId,
                Room = new Room { Id = RoomId }
            };
            return patient;
        }
    }
}
