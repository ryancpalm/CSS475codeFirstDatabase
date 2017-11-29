using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class DoctorSpecialty
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
