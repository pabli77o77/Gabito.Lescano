using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;

namespace AdSanare.Repository
{
    public class EvolucionRepository:GenericRepository<Evolucion>,IEvolucionRepository
    {
        public EvolucionRepository(AdSanareDbContext context) : base(context)
        {

        }
    }
}
