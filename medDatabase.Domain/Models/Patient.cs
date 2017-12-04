using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Validation;

namespace medDatabase.Domain.Models
{
    public class Patient : IHasRoom, IHasSsn
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [SsnValidation(ErrorMessage = "SSN must be a unique nine-digit integer.")]
        public string Ssn { get; set; }

        public string GetSsn()
        {
            return Ssn;
        }

        public void SetSsn(string ssn)
        {
            Ssn = ssn;
        }

        [Required]
        public int RoomId { get; set; }

        public int GetRoomId()
        {
            return RoomId;
        }

        [Required]
        public virtual Room Room { get; set; }

        public void SetRoom(Room room)
        {
            Room = room;
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; }
    }
}
