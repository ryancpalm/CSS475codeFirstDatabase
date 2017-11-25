using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        // No '-'
        [StringLength(9)]
        [Required]
        public string Ssn { get; set; }

        // Will continue adding attributes later...
    }
}
