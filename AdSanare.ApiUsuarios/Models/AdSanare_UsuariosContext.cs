using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdSanare.ApiUsuarios.Models
{
    public partial class AdSanare_UsuariosContext : DbContext
    {
        public AdSanare_UsuariosContext()
        {
        }

        public AdSanare_UsuariosContext(DbContextOptions<AdSanare_UsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AdSanareUsuarios");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
