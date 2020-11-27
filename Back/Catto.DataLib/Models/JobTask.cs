using System;
using System.Collections.Generic;
using System.Text;

namespace Catto.DataLib.Models
{
    public enum Statuses
    {
        New,
        Choosed,
        Working,
        Vefication,
        Done
    }

    public class JobTask
    {
        public int Id { get; set; }
        public Statuses Status { get; set; }
        public Project Project { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public Employee Executor { get; set; }
        public Employee Verifier { get; set; }
        public DateTime DeadLine { get; set; }
        public int Priority { get; set; }
    }
}
