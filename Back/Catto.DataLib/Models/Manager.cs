using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catto.DataLib.Models
{
    [Table("Managers")]
    public class Manager : Employee
    {                         
        [MaxLength(50)]
        public string Rank { get; set; }        
        public List<Technician> Technicians { get; set; }
        public List<Property> Properties { get; set; }
        public List<Project> Project {get; set;}

    }
}