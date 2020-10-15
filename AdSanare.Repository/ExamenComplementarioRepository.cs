using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdSanare.Repository
{
    public class ExamenComplementarioRepository : GenericRepository<ExamenComplementario>, IExamenComplementarioRepository
    {
        public ExamenComplementarioRepository(AdSanareDbContext context):base(context)
        {

        }
        public override IEnumerable<ExamenComplementario> Get()
        {
            return _context.Set<ExamenComplementario>().Include(x=>x.Paciente).ToList();
        }

        public override ExamenComplementario Get(int Id)
        {
            return _context.Set<ExamenComplementario>().Where(x=>x.Id==Id).Include(x=>x.Paciente).First();
        }

    }
}
