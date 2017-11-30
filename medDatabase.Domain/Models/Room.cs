using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Domain.Models
{
    public class Room : IMedicalDatabaseModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
