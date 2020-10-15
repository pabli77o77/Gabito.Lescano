using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using AdSanare.UOW.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Logic
{
    public class EvolucionLogic : IEvolucionLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public EvolucionLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Evolucion entidad)
        {
            Servicio servicio = _unitOfWork.Servicios.Get(entidad.ServicioInternacion.Id);
            entidad.ServicioInternacion = servicio;
            Cama cama = _unitOfWork.Camas.Get(entidad.CamaInternacion.Id);
            entidad.CamaInternacion = cama;
            Ingreso ingreso = _unitOfWork.Ingresos.Get(entidad.Ingreso.Id);
            entidad.Ingreso = ingreso;
            _unitOfWork.ExamenesFisicos.Add(entidad.ExamenFisico);
            _unitOfWork.Evoluciones.Add(entidad);
            _unitOfWork.Complete();
        }

        public IEnumerable<Evolucion> Get()
        {
            return _unitOfWork.Evoluciones.Get();
        }

        public Evolucion Get(int Id)
        {
            return _unitOfWork.Evoluciones.Get(Id);
        }

        public IEnumerable<Evolucion> Get(List<Expression<Func<Evolucion, bool>>> where = null, Func<IQueryable<Evolucion>, IOrderedQueryable<Evolucion>> orden = null, string include = "")
        {
            return _unitOfWork.Evoluciones.Get(where, orden, include);
        }

        public void Remove(int Id)
        {
            Evolucion evolucion = _unitOfWork.Evoluciones.Get(Id);
            if (evolucion != null)
            {
                _unitOfWork.Evoluciones.Remove(evolucion);
                _unitOfWork.Complete();
            }
        }

        public void Update(Evolucion entidad)
        {
            Servicio servicio = _unitOfWork.Servicios.Get(entidad.ServicioInternacion.Id);
            entidad.ServicioInternacion = servicio;
            Cama cama = _unitOfWork.Camas.Get(entidad.CamaInternacion.Id);
            entidad.CamaInternacion = cama;
            Ingreso ingreso = _unitOfWork.Ingresos.Get(entidad.Ingreso.Id);
            entidad.Ingreso = ingreso;
            _unitOfWork.ExamenesFisicos.Update(entidad.ExamenFisico);
            _unitOfWork.Evoluciones.Update(entidad);
            _unitOfWork.Complete();
        }

        public IEnumerable<Cama> GetCamas()
        {
            return _unitOfWork.Camas.Get();
        }

        public IEnumerable<Servicio> GetServicios()
        {
            return _unitOfWork.Servicios.Get();
        }
    }
}
