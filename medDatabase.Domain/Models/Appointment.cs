﻿using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Appointment : IMedicalDatabaseModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public virtual Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public virtual Employee Doctor { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }
    }
}
