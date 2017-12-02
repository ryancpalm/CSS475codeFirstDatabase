using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Doctor : IMedicalDatabaseModel, IHasEmployee, IHasDoctorSpecialty
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
        public int DoctorSpecialtyId { get; set; }

        public int GetDoctorSpecialtyId()
        {
            return DoctorSpecialtyId;
        }

        [Required]
        public virtual DoctorSpecialty DoctorSpecialty { get; set; }

        public void SetDoctorSpecialty(DoctorSpecialty specialty)
        {
            DoctorSpecialty = specialty;
        }
    }
}
