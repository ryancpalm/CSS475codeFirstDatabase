using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class NurseSpecialty
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
