using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Validation;

namespace medDatabase.Domain.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int rxID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int refill { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int refill { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int refill { get; set; }

        [Required]
        public Medication Meds { get; set; }

        [Required]
        public Doctor prescriber { get; set; }

    }
}
