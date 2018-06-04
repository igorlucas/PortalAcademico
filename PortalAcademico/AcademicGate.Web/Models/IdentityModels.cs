using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AcademicGate.Web.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }

        public Address Address { get; set; }

        [StringLength(80)]
        public string Formation { get; set; }

        [StringLength(40)]
        public string Permission { get; set; }

        [StringLength(80)]
        public string RA { get; set; }

        public string MotherName { get; set; }

        public DateTime IngressedYear { get; set; }

        public string IngressedSerie { get; set; }

        public string CurrentySerie { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AcademicCalendar> AcademicCalendars { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ReportCard> ReportCards { get; set; }
        public DbSet<RegistrationStudentTeam> RegistrationStudentTeams { get; set; }
        public DbSet<Frequence> Frequences { get; set; }    

    }
}