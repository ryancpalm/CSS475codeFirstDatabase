using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Doctor
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
