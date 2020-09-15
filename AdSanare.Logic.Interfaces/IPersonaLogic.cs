using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IPersonaLogic
    {
        void Add(Persona entidad);
        IEnumerable<Persona> Get();
        Persona Get(int Id);
        IEnumerable<Persona> Get(List<Expression<Func<Persona, bool>>> where = null, Func<IQueryable<Persona>, IOrderedQueryable<Persona>> orden = null, string include = "");
        void Remove(int Id);
        void Update(Persona entidad);
    }
}
