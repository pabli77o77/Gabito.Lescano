using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IExamenComplementarioLogic
    {
        void Add(ExamenComplementario examenComplementario);
        IEnumerable<ExamenComplementario> Get();
        ExamenComplementario Get(int Id);
        IEnumerable<ExamenComplementario> Get(List<Expression<Func<ExamenComplementario, bool>>> filtros = null, Func<IQueryable<ExamenComplementario>, IOrderedQueryable<ExamenComplementario>> ordenamiento = null, string incluir = "");
        void Remove(int Id);
        void Update(ExamenComplementario examenComplementario);
    }
}
