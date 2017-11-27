﻿using System;
using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Prescription
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public Employee Doctor { get; set; }

        [Required]
        public int MedicationId { get; set; }

        [Required]
        public Medication Medication { get; set; }

        [Required]
        public int Refills { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
