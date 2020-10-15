using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IExamenComplementarioLogic
    {
        void Add(ExamenComplementario entidad);
        IEnumerable<ExamenComplementario> Get();
        ExamenComplementario Get(int Id);
        IEnumerable<ExamenComplementario> Get(List<Expression<Func<ExamenComplementario, bool>>> where = null, Func<IQueryable<ExamenComplementario>, IOrderedQueryable<ExamenComplementario>> orden = null, string include = "");
        void Remove(int Id);
        void Update(ExamenComplementario entidad);
    }
}
