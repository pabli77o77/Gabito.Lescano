using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;
using System.Linq;

namespace AdSanare.Repository
{
    public class UsuarioRepository : GenericUserRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AdSanareUsuariosDbContext context) : base(context)
        {
        }
        public Usuario Get(string Id)
        {
            return _context.Set<Usuario>().Find(Id);
        }

        public Usuario GetByUserName(string Name)
        {
            return _context.Set<Usuario>().Where(x => x.UserName == Name).FirstOrDefault();
        }
    }
}
