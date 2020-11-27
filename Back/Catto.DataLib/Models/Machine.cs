using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catto.DataLib.Models
{
    public class Machine
    {
        [Key]
        public string Model { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        public int AccessLevel { get; set; }

        [MaxLength(150)]
        public string Speciality { get; set; }
        
        public List<Property> PropList { get; set; }
        public List<Malfuntions> Malfuntions { get; set; }

    }
}