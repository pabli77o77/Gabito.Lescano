using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class CamaLogic : ICamaLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CamaLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Cama nuevaCama)
        {
            Servicio servicio = _unitOfWork.Servicios.Get(nuevaCama.ServicioInternacion.Id);
            nuevaCama.ServicioInternacion = servicio;
            _unitOfWork.Camas.Add(nuevaCama);
            _unitOfWork.Complete();
        }

        public IEnumerable<Cama> Get()
        {
            return _unitOfWork.Camas.Get();
        }

        public Cama Get(int Id)
        {
            return _unitOfWork.Camas.Get(Id);
        }

        public IEnumerable<Cama> Get(List<Expression<Func<Cama, bool>>> filtros = null, Func<IQueryable<Cama>, IOrderedQueryable<Cama>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.Camas.Get(filtros, ordenamiento, incluir);
        }

        public void Remove(int Id)
        {
            Cama cama = _unitOfWork.Camas.Get(Id);
            if (cama != null)
            {
                cama.BajaLogica = true;
                cama.FechaBaja = DateTime.Now;
                _unitOfWork.Camas.Update(cama);
                _unitOfWork.Complete();
            }
        }

        public void Update(Cama cama)
        {
            _unitOfWork.Camas.Update(cama);
            _unitOfWork.Complete();
        }
    }
}
