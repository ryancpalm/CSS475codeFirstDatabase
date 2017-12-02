using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Nurse : IHasEmployee, IHasNurseSpecialty
    {
        [Required]
        public int EmployeeId { get; set; }

        public int GetEmployeeId()
        {
            return EmployeeId;
        }

        [Required]
        public virtual Employee Employee { get; set; }

        public void SetEmployee(Employee employee)
        {
            Employee = employee;
        }

        [Required]
        public int NurseSpecialtyId { get; set; }

        public int GetNurseSpecialtyId()
        {
            return NurseSpecialtyId;
        }

        [Required]
        public virtual NurseSpecialty NurseSpecialty { get; set; }

        public void SetNurseSpecialty(NurseSpecialty specialty)
        {
            NurseSpecialty = specialty;
        }
    }
}
