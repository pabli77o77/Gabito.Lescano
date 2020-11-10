using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IObraSocialLogic
    {
        void Add(ObraSocial obraSocial);
        IEnumerable<ObraSocial> Get();
        ObraSocial Get(int Id);
        IEnumerable<ObraSocial> Get(List<Expression<Func<ObraSocial, bool>>> filtros = null, Func<IQueryable<ObraSocial>, IOrderedQueryable<ObraSocial>> ordenamiento = null, string incluir = "");
        void Remove(int Id);
        void Update(ObraSocial obraSocial);
    }
}
