﻿using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Validation;

namespace medDatabase.Domain.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [SsnValidation(ErrorMessage = "SSN must be a unique nine-digit integer.")]
        public string Ssn { get; set; }

        [Required]
        public DateTime AdmitDate { get; set; }

        public DateTime DischDate { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        [Range(16, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }
        
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
    }
}
