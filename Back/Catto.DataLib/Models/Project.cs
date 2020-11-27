﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catto.DataLib.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public Property Property { get; set; }
        [Required]
        [MaxLength(350)]
        public string MalfunctionType { get; set; }
        public string MalfunctionDesc { get; set; }
        public List<Technician> Technicians { get; set; } = new List<Technician>();
        public List<Manager> Managers { get; set; } = new List<Manager>();
        [Required]
        public Employee Creator { get; set; }

        [Timestamp]
        public DateTime CreationTime { get; set; }
        public int Priority { get; set; }
        [MaxLength(300)]
        public string Status { get; set; }
        public DateTime PlannedTime { get; set; }

        public DateTime ComplitionTime { get; set; }        
        public string Comment { get; set; }
        public List<JobTask> Tasks { get; set; }
    }
}