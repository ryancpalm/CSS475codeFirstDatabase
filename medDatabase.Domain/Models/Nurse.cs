using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Nurse : IMedicalDatabaseModel
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
