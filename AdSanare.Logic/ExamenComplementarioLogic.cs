using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class ExamenComplementarioLogic : IExamenComplementarioLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamenComplementarioLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ExamenComplementario nuevoExamenComplementario)
        {
            List<Expression<Func<Paciente, bool>>> filtroDni = new List<Expression<Func<Paciente, bool>>>();
            filtroDni.Add(p => p.Documento.Trim().ToUpper().Contains(nuevoExamenComplementario.Paciente.Documento.Trim().ToUpper()));
            Paciente paciente = _unitOfWork.Pacientes.Get(filtroDni).FirstOrDefault();
            nuevoExamenComplementario.Paciente = paciente;
            _unitOfWork.ExamenesComplementarios.Add(nuevoExamenComplementario);
            _unitOfWork.Complete();
        }

        public IEnumerable<ExamenComplementario> Get()
        {
            return _unitOfWork.ExamenesComplementarios.Get();
        }

        public ExamenComplementario Get(int Id)
        {
            return _unitOfWork.ExamenesComplementarios.Get(Id);
        }

        public IEnumerable<ExamenComplementario> Get(List<Expression<Func<ExamenComplementario, bool>>> filtros = null, Func<IQueryable<ExamenComplementario>, IOrderedQueryable<ExamenComplementario>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.ExamenesComplementarios.Get(filtros, ordenamiento, incluir);
        }

        public void Remove(int Id)
        {
            ExamenComplementario examen = _unitOfWork.ExamenesComplementarios.Get(Id);
            if (examen != null)
            {
                examen.BajaLogica = true;
                examen.FechaBaja = DateTime.Now;
                _unitOfWork.ExamenesComplementarios.Update(examen);
                _unitOfWork.Complete();
            }
        }

        public void Update(ExamenComplementario examenComplementario)
        {
            _unitOfWork.ExamenesComplementarios.Update(examenComplementario);
            _unitOfWork.Complete();
        }
    }
}
