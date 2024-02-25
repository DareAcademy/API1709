using ClinicAngularAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicAngularAPI.data
{
    public class ClinicContext: IdentityDbContext<ApplicationUsers>
    {
        IConfiguration config;
        public ClinicContext(IConfiguration _config)
        {
            config = _config;
        }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("clinicConn"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
