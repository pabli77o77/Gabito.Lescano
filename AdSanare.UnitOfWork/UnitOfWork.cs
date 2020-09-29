using AdSanare.Context;
using AdSanare.Repository;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW.Interfaces;
using System;

namespace AdSanare.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdSanareDbContext _context;

        public IPacienteRepository Pacientes { get; private set; }

        public UnitOfWork(AdSanareDbContext context)
        {
            _context = context;
            Pacientes = new PacienteRepository(_context);

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
