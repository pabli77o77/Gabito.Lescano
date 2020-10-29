using AdSanare.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdSanare.Context
{
    public class AdSanareUsuariosDbContext: IdentityDbContext<Usuario>
    {
        public AdSanareUsuariosDbContext(DbContextOptions<AdSanareUsuariosDbContext> options)
            : base(options)
        {

        }

        public DbSet<Auditoria> Auditorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
