using System;
using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(9)]
        [Required]
        public string Ssn { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        [Range(16, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool OnSite { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
    }
}
