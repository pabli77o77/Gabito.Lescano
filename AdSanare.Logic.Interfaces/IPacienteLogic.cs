using AdSanare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic.Interfaces
{
    public interface IPacienteLogic
    {
        void Add(Paciente paciente);
        IEnumerable<Paciente> Get();
        Paciente Get(int Id);
        IEnumerable<Paciente> Get(List<Expression<Func<Paciente, bool>>> filtros = null, Func<IQueryable<Paciente>, IOrderedQueryable<Paciente>> ordenamiento = null, string incluir = "");
        void Remove(int Id);
        void Update(Paciente paciente);
    }
}
