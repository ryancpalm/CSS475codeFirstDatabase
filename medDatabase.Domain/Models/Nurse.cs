using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Nurse
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public virtual Employee Employee { get; set; }

        [Required]
        public int NurseSpecialtyId { get; set; }

        [Required]
        public virtual NurseSpecialty NurseSpecialty { get; set; }
    }
}
