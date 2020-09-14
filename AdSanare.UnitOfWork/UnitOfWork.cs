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

        public IPersonaRepository Personas { get; private set; }

        public UnitOfWork(AdSanareDbContext context)
        {
            _context = context;
            Personas = new PersonaRepository(_context);

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
