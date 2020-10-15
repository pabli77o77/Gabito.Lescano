using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Repository.Interfaces;
using System.Collections.Generic;

namespace AdSanare.Repository
{
    public class IngresoRepository:GenericRepository<Ingreso>,IIngresoRepository
    {
        public IngresoRepository(AdSanareDbContext context) : base(context)
        {
        }
    }
}
