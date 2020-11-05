using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;

namespace AdSanare.Repository
{
    public class ObraSocialRepository : GenericRepository<ObraSocial>, IObraSocialRepository
    {
        public ObraSocialRepository(AdSanareDbContext context) : base(context)
        {
        }
    }
}
