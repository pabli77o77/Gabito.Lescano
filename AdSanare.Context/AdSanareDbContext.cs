using AdSanare.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdSanare.Context
{
    public class AdSanareDbContext:DbContext
    {
        public AdSanareDbContext(DbContextOptions<AdSanareDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
