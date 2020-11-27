using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Catto.DataLib.Models
{
    public class Employee
    {
        [Key]
        [ForeignKey("Account")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FamilyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Department { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Role {get; set;}

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public int Phone { get; set; }

        public Account Account {get; set;}

    }
}
