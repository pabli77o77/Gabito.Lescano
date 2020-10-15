using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;

namespace AdSanare.Repository
{
    public class ServicioRepository:GenericRepository<Servicio>,IServicioRepository
    {
        public ServicioRepository(AdSanareDbContext context):base(context)
        {

        }
    }
}
