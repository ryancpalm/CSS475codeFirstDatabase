using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Models;

namespace medDatabase.Domain.Mockaroo.Models
{
    public class MockarooNurse : IMockarooConvertible<Nurse>
    {
        public int EmployeeId { get; set; }

        public int NurseSpecialtyId { get; set; }

        public Nurse Convert()
        {
            var nurse = new Nurse
            {
                EmployeeId = EmployeeId,
                Employee = new Employee { Id = EmployeeId },
                NurseSpecialtyId = NurseSpecialtyId,
                NurseSpecialty = new NurseSpecialty { Id = NurseSpecialtyId }
            };
            return nurse;
        }
    }
}
