using AdSanare.Context;
using AdSanare.Repository;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW.Interfaces;

namespace AdSanare.UOW
{
    public class UsuarioUnitOfWork : IUserUnitOfWork
    {
        private readonly AdSanareUsuariosDbContext _context;        
        public IUsuarioRepository Usuarios { get; private set; }
        public IAuditoriaRepository Auditorias { get; private set; }

        public UsuarioUnitOfWork(AdSanareUsuariosDbContext context)
        {
            _context = context;
            Usuarios = new UsuarioRepository(_context);
            Auditorias = new AuditoriaRepository(_context);
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
