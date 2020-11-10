using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IServicioLogic
    {
        void Add(Servicio servicio);
        IEnumerable<Servicio> Get();
        Servicio Get(int Id);
        IEnumerable<Servicio> Get(List<Expression<Func<Servicio, bool>>> filtros = null, Func<IQueryable<Servicio>, IOrderedQueryable<Servicio>> ordenaiento = null, string incluir = "");
        void Remove(int Id);
        void Update(Servicio servicio);
    }
}
