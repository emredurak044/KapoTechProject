using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KapoTechProject.Models
{
    public class KapoTechContext : DbContext
    {
        public KapoTechContext(): base("Name = KapoTechConnection")
        {
        }
        public DbSet<Info> Infos { get; set; }   
        public DbSet<Project> Projects { get; set; }   
        public DbSet<Service> Services { get; set; }
    }
}