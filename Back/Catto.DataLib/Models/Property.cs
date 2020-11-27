using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catto.DataLib.Models
{
    public class Property
    {
        public int Id { get; set; }        

        [Required]
        public Machine Machine { get; set; }

        [Required]
        [MaxLength(250)]
        public string Location {get; set;}
        [Required]
        [MaxLength(50)]
        public string Department { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
        
        public Manager Manager { get; set; }
        public List<RepairOrder> RepairOrders {get; set;}

    }
}