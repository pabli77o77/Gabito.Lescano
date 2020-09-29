using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class PacienteLogic : IPacienteLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public PacienteLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Paciente entidad)
        {
            _unitOfWork.Pacientes.Add(entidad);
            _unitOfWork.Complete();
        }

        public IEnumerable<Paciente> Get()
        {
            return _unitOfWork.Pacientes.Get();
        }

        public Paciente Get(int Id)
        {
            return _unitOfWork.Pacientes.Get(Id);
        }

        public IEnumerable<Paciente> Get(List<Expression<Func<Paciente, bool>>> where = null, Func<IQueryable<Paciente>, IOrderedQueryable<Paciente>> orden = null, string include = "")
        {
            return _unitOfWork.Pacientes.Get(where, orden, include);            
        }

        public void Remove(int Id)
        {
            Paciente paciente = _unitOfWork.Pacientes.Get(Id);
            if (paciente != null)
            {
                _unitOfWork.Pacientes.Remove(paciente);
                _unitOfWork.Complete();
            }
        }

        public void Update(Paciente entidad)
        {
            _unitOfWork.Pacientes.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
