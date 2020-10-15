using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;

namespace AdSanare.Repository
{
    public class ExamenFisicoRepository:GenericRepository<ExamenFisico>, IExamenFisicoRepository
    {
        public ExamenFisicoRepository(AdSanareDbContext context):base(context)
        {

        }
    }
}
