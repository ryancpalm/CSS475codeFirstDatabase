using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Validation;

namespace medDatabase.Domain.Models
{
    public class Doctor
    {
        [Key]        
        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Doctor_Specialty DSpec { get; set; }      
    }
}
