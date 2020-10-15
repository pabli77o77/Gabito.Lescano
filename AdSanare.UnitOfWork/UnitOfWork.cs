using AdSanare.Context;
using AdSanare.Repository;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW.Interfaces;

namespace AdSanare.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdSanareDbContext _context;

        public IPacienteRepository Pacientes { get; private set; }
        public IExamenComplementarioRepository ExamenesComplementarios { get; private set; }
        public ICamaRepository Camas { get; private set; }
        public IServicioRepository Servicios { get; private set; }

        public UnitOfWork(AdSanareDbContext context)
        {
            _context = context;
            Pacientes = new PacienteRepository(_context);
            ExamenesComplementarios = new ExamenComplementarioRepository(_context);
            Camas = new CamaRepository(_context);
            Servicios = new ServicioRepository(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
