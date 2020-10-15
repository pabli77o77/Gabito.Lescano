using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AdSanare.Logic
{
    public class ExamenComplementarioLogic : IExamenComplementarioLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamenComplementarioLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ExamenComplementario entidad)
        {
            List<Expression<Func<Paciente, bool>>> listaWhere = new List<Expression<Func<Paciente, bool>>>();
            listaWhere.Add(p => p.Documento.Trim().ToUpper().Contains(entidad.Paciente.Documento.Trim().ToUpper()));
            Paciente paciente = _unitOfWork.Pacientes.Get(listaWhere).FirstOrDefault();
            entidad.Paciente = paciente;
            _unitOfWork.ExamenesComplementarios.Add(entidad);
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

        public IEnumerable<ExamenComplementario> Get(List<Expression<Func<ExamenComplementario, bool>>> where = null, Func<IQueryable<ExamenComplementario>, IOrderedQueryable<ExamenComplementario>> orden = null, string include = "")
        {
            return _unitOfWork.ExamenesComplementarios.Get(where, orden, include);
        }

        public void Remove(int Id)
        {
            ExamenComplementario examen = _unitOfWork.ExamenesComplementarios.Get(Id);
            if (examen != null)
            {
                _unitOfWork.ExamenesComplementarios.Remove(examen);
                _unitOfWork.Complete();
            }
        }

        public void Update(ExamenComplementario entidad)
        {
            _unitOfWork.ExamenesComplementarios.Update(entidad);
            _unitOfWork.Complete();
        }
    }
}
