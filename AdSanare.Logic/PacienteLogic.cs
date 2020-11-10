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
        public void Add(Paciente nuevoPaciente)
        {
            ObraSocial obraSocial = _unitOfWork.ObrasSociales.Get(nuevoPaciente.ObraSocial.Id);
            nuevoPaciente.ObraSocial = obraSocial;
            _unitOfWork.Pacientes.Add(nuevoPaciente);
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

        public IEnumerable<Paciente> Get(List<Expression<Func<Paciente, bool>>> filtros = null, Func<IQueryable<Paciente>, IOrderedQueryable<Paciente>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.Pacientes.Get(filtros, ordenamiento, incluir);            
        }

        public void Remove(int Id)
        {
            Paciente paciente = _unitOfWork.Pacientes.Get(Id);
            if (paciente != null)
            {
                paciente.BajaLogica = true;
                paciente.FechaBaja = DateTime.Now;
                _unitOfWork.Pacientes.Update(paciente);
                _unitOfWork.Complete();
            }
        }

        public void Update(Paciente paciente)
        {
            _unitOfWork.Pacientes.Update(paciente);
            _unitOfWork.Complete();
        }
    }
}
