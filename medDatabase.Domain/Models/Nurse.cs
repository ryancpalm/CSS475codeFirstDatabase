using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Validation;

namespace medDatabase.Domain.Models
{
    public class Nurse
    {
        [Key]        
        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Nurse_Specialty NSpec { get; set; }      
    }
}
