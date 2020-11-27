using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Catto.DataLib.Models
{
    public class Malfuntions
    {
        public int Id { get; set; }
        public Machine Machine { get; set; }
        [MaxLength(350)]
        public string MalfunctionType { get; set; }

        [MaxLength(350)]
        public string ManualLink { get; set; }
    }
}
