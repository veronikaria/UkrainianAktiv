using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;

namespace UkrainianAktiv.Core.Models
{
    public class DataContext : IdentityDbContext<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole<Guid>, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public IConfigurationRoot Configuration { get; set; }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ScheduleItem> Schedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./ukrainianaktiv.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
