using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class IngresoLogic : IIngresoLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngresoLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Ingreso pacienteIngreso)
        {
            List<Expression<Func<Paciente, bool>>> filtroDni = new List<Expression<Func<Paciente, bool>>>();
            filtroDni.Add(p => p.Documento.Trim().ToUpper().Contains(pacienteIngreso.Paciente.Documento.Trim().ToUpper()));
            Paciente paciente = _unitOfWork.Pacientes.Get(filtroDni).FirstOrDefault();
            if (paciente == null) 
            {
                _unitOfWork.Dispose();
                return;
            }
            else
            {
                pacienteIngreso.Paciente = paciente;
                _unitOfWork.Ingresos.Add(pacienteIngreso);
                _unitOfWork.Complete();
            }
        }

        public IEnumerable<Ingreso> Get()
        {
            return _unitOfWork.Ingresos.Get();
        }

        public Ingreso Get(int Id)
        {
            return _unitOfWork.Ingresos.Get(Id);
        }

        public IEnumerable<Ingreso> Get(List<Expression<Func<Ingreso, bool>>> where = null, Func<IQueryable<Ingreso>, IOrderedQueryable<Ingreso>> orden = null, string include = "")
        {
            return _unitOfWork.Ingresos.Get(where, orden, include);
        }

        public void Remove(int Id)
        {
            Ingreso ingreso = _unitOfWork.Ingresos.Get(Id);
            if (ingreso != null)
            {
                _unitOfWork.Ingresos.Remove(ingreso);
                _unitOfWork.Complete();
            }
        }

        public void Update(Ingreso entidad)
        {
            _unitOfWork.Ingresos.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
