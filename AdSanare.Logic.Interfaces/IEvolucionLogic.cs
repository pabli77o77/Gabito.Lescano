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
        void Add(Evolucion entidad);
        IEnumerable<Evolucion> Get();
        Evolucion Get(int Id);
        IEnumerable<Evolucion> Get(List<Expression<Func<Evolucion, bool>>> where = null, Func<IQueryable<Evolucion>, IOrderedQueryable<Evolucion>> orden = null, string include = "");
        void Remove(int Id);
        void Update(Evolucion entidad);
        IEnumerable<Servicio> GetServicios();
        IEnumerable<Cama> GetCamas();
    }
}
