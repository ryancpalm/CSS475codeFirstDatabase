using System;
using System.ComponentModel.DataAnnotations;
using medDatabase.Domain.Validation;

namespace medDatabase.Domain.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public int medID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
                
        [Required]
        [Range(0, int.MaxValue)]
        public int RecDosage { get; set; }        
    }
}
