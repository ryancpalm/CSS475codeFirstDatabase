using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Address : IHasPatient
    {
        [Required]
        public int PatientId { get; set; }

        public int GetPatientId()
        {
            return PatientId;
        }

        [Required]
        public virtual Patient Patient { get; set; }

        public void SetPatient(Patient patient)
        {
            Patient = patient;
        }

        [Required]
        public int HouseNumber { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
