using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;

namespace AdSanare.Repository
{
    public class DomicilioRepository : GenericRepository<Domicilio>, IDomicilioRepository
    {
        public DomicilioRepository(AdSanareDbContext context) : base(context)
        {
        }
    }
}
