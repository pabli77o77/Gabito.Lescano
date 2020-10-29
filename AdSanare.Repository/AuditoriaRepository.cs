using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;

namespace AdSanare.Repository
{
    public class AuditoriaRepository : GenericUserRepository<Auditoria>, IAuditoriaRepository
    {

        public AuditoriaRepository(AdSanareUsuariosDbContext context) : base(context)
        {
        }

    }
}
