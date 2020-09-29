using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IPacienteLogic
    {
        void Add(Paciente entidad);
        IEnumerable<Paciente> Get();
        Paciente Get(int Id);
        IEnumerable<Paciente> Get(List<Expression<Func<Paciente, bool>>> where = null, Func<IQueryable<Paciente>, IOrderedQueryable<Paciente>> orden = null, string include = "");
        void Remove(int Id);
        void Update(Paciente entidad);
    }
}
