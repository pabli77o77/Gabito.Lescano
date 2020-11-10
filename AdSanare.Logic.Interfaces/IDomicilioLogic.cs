using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IDomicilioLogic
    {
        void Add(Domicilio domicilio);
        IEnumerable<Domicilio> Get();
        Domicilio Get(int Id);
        IEnumerable<Domicilio> Get(List<Expression<Func<Domicilio, bool>>> filtros = null, Func<IQueryable<Domicilio>, IOrderedQueryable<Domicilio>> ordenamiento = null, string incluir = "");
        void Remove(int Id);
        void Update(Domicilio domicilio);
    }
}
