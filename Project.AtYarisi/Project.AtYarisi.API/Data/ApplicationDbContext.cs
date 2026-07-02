using Microsoft.EntityFrameworkCore;
using Project.AtYarisi.API.Models;

namespace Project.AtYarisi.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Horse> Horses { get; set; }
        public DbSet<Jockey> Jockeys { get; set; }
        public DbSet<Racecourse> Racecourses { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
    }
}
