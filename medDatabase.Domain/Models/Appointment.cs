using System;
using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Appointment
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
        public DateTime DateAndTime { get; set; }
    }
}
