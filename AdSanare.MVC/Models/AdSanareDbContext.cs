using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdSanare.MVC.Models
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
