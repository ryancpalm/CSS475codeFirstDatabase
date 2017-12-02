using System.ComponentModel.DataAnnotations;

namespace medDatabase.Domain.Models
{
    public class Illness
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
