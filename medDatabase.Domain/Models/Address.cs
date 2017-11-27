using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Validation;

namespace medDatabase.Domain.Models
{
    public class Patient
    {        
        [Required]
        public int houseNum { get; set; }

        [Required]
        [StringLength(30)]
        public string Street { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(30)]
        public string State { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [Required]
        [Range(0, 99999)]
        public int zipcode { get; set; }

        [Required]
        [SsnValidation(ErrorMessage = "SSN must be a unique nine-digit integer.")]
        public string Ssn { get; set; }        
    }
}
