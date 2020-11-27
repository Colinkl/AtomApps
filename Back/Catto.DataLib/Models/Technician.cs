using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Catto.DataLib.Models
{
    [Table("Technician")]
    public class Technician : Employee
    {                
        [Required]        
        public int AccessLevel { get; set; }
        public string Speciality { get; set; }
        public Manager Manager { get; set; }
        public List<RepairOrder> RepairOrders { get; set; }
    }
}
