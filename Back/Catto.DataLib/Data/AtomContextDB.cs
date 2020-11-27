using Catto.DataLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catto.DataLib.Data
{
    public class AtomContextDB : DbContext
    {
        public AtomContextDB(DbContextOptions<AtomContextDB> options) : base(options)
        {

        }
        
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}
