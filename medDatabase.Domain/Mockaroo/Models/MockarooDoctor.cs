using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Models;

namespace medDatabase.Domain.Mockaroo.Models
{
    public class MockarooDoctor : IMockarooConvertible<Doctor>
    {
        public int EmployeeId { get; set; }

        public int DoctorSpecialtyId { get; set; }

        public Doctor Convert()
        {
            var doctor = new Doctor
            {
                EmployeeId = EmployeeId,
                Employee = new Employee {Id = EmployeeId},
                DoctorSpecialtyId = DoctorSpecialtyId,
                DoctorSpecialty = new DoctorSpecialty {Id = DoctorSpecialtyId}
            };
            return doctor;
        }
    }
}
