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
        public void Add(Evolucion nuevaEvolucion)
        {
            Servicio servicio = _unitOfWork.Servicios.Get(nuevaEvolucion.ServicioInternacion.Id);
            nuevaEvolucion.ServicioInternacion = servicio;
            Cama cama = _unitOfWork.Camas.Get(nuevaEvolucion.CamaInternacion.Id);
            nuevaEvolucion.CamaInternacion = cama;
            Ingreso ingreso = _unitOfWork.Ingresos.Get(nuevaEvolucion.Ingreso.Id);
            nuevaEvolucion.Ingreso = ingreso;
            _unitOfWork.Evoluciones.Add(nuevaEvolucion);
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

        public IEnumerable<Evolucion> Get(List<Expression<Func<Evolucion, bool>>> filtros = null, Func<IQueryable<Evolucion>, IOrderedQueryable<Evolucion>> ordenamiento = null, string incluir = "")
        {
            return _unitOfWork.Evoluciones.Get(filtros, ordenamiento, incluir);
        }

        public void Remove(int Id)
        {
            Evolucion evolucion = _unitOfWork.Evoluciones.Get(Id);
            if (evolucion != null)
            {
                evolucion.BajaLogica = true;
                evolucion.FechaBaja = DateTime.Now;
                _unitOfWork.Evoluciones.Update(evolucion);
                _unitOfWork.Complete();
            }
        }

        public void Update(Evolucion evolucion)
        {
            Servicio servicio = _unitOfWork.Servicios.Get(evolucion.ServicioInternacion.Id);
            evolucion.ServicioInternacion = servicio;
            Cama cama = _unitOfWork.Camas.Get(evolucion.CamaInternacion.Id);
            evolucion.CamaInternacion = cama;
            Ingreso ingreso = _unitOfWork.Ingresos.Get(evolucion.Ingreso.Id);
            evolucion.Ingreso = ingreso;
            _unitOfWork.ExamenesFisicos.Update(evolucion.ExamenFisico);
            _unitOfWork.Evoluciones.Update(evolucion);
            _unitOfWork.Complete();
        }

        public IEnumerable<Cama> GetCamas()
        {
            List<Expression<Func<Cama, bool>>> filtros = new List<Expression<Func<Cama, bool>>>();
            filtros.Add(c => !c.BajaLogica);
            return _unitOfWork.Camas.Get(filtros);
        }

        public IEnumerable<Servicio> GetServicios()
        {
            List<Expression<Func<Servicio, bool>>> filtros = new List<Expression<Func<Servicio, bool>>>();
            filtros.Add(c => !c.BajaLogica);
            return _unitOfWork.Servicios.Get(filtros);
        }
    }
}
