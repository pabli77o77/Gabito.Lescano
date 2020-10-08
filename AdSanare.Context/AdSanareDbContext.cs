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
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cama> Camas { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Evolucion> Evoluciones { get; set; }
        public DbSet<ExamenComplementario> ExamenesComplementarios { get; set; }
        public DbSet<ExamenFisico> ExamenesFisicos { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<ObraSocial> ObrasSociales { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
    }
}
