using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Address
    {
        [Required]
        public int PatientId { get; set; }

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
