using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AdSanare.Logic.Interfaces
{
    public interface IEvolucionLogic
    {
        void Add(Evolucion evolucion);
        IEnumerable<Evolucion> Get();
        Evolucion Get(int Id);
        IEnumerable<Evolucion> Get(List<Expression<Func<Evolucion, bool>>> filtros = null, Func<IQueryable<Evolucion>, IOrderedQueryable<Evolucion>> ordenamiento = null, string incluir = "");
        void Remove(int Id);
        void Update(Evolucion evolucion);
        IEnumerable<Servicio> GetServicios();
        IEnumerable<Cama> GetCamas();
    }
}
