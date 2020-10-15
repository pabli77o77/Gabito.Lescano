using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;

namespace AdSanare.Repository
{
    public class CamaRepository:GenericRepository<Cama>,ICamaRepository
    {
        public CamaRepository(AdSanareDbContext context):base(context)
        {

        }
    }
}
