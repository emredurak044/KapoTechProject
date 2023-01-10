using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace KapoTechProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NameSurname { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // authenticationType'ın CookieAuthenticationOptions.AuthenticationType'ta tanımlı olan ile eşleşmesi gerektiğine dikkat edin
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Özel kullanıcı taleplerini buraya ekleyin
            return userIdentity;
        }
    }
    public class KapoTechContext : IdentityDbContext<ApplicationUser>
    {
        public KapoTechContext() : base("Name = KapoTechConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Team> Teams { get; set; }

        public static KapoTechContext Create()
        {
            return new KapoTechContext();
        }
    }
   
}