using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Room
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
