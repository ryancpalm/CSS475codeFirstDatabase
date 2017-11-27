using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Medication
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Dosage { get; set; }
    }
}
