using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Doctor : IMedicalDatabaseModel
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public virtual Employee Employee { get; set; }

        [Required]
        public int DoctorSpecialtyId { get; set; }

        [Required]
        public virtual DoctorSpecialty DoctorSpecialty { get; set; }
    }
}
