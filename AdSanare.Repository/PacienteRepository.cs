using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;

namespace AdSanare.Repository
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(AdSanareDbContext context) : base(context)
        {
        }
    }
}
