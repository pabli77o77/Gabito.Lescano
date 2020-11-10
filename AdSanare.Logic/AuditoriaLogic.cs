using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class AuditoriaLogic : IAuditoriaLogic
    {
        private readonly IUserUnitOfWork _unitOfWork;

        public AuditoriaLogic(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Auditoria auditoria)
        {
            _unitOfWork.Auditorias.Add(auditoria);
            _unitOfWork.Complete();
        }

        public IEnumerable<Auditoria> Get()
        {
            return _unitOfWork.Auditorias.Get();
        }

        public Auditoria Get(int Id)
        {
            return _unitOfWork.Auditorias.Get(Id);
        }

        public IEnumerable<Auditoria> Get(List<Expression<Func<Auditoria, bool>>> filtros = null, Func<IQueryable<Auditoria>, IOrderedQueryable<Auditoria>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.Auditorias.Get(filtros, ordenamiento, incluir);
        }
    }
}
