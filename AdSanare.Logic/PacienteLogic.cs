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
            List<Expression<Func<Paciente, bool>>> filtroPaciente = new List<Expression<Func<Paciente, bool>>>();
            filtroPaciente.Add(x => x.Id == Id);
            Paciente paciente = _unitOfWork.Pacientes.Get(filtroPaciente,null, "Domicilio").FirstOrDefault();
            if (paciente != null)
            {
                paciente.BajaLogica = true;
                paciente.FechaBaja = DateTime.Now;
                if (paciente.Domicilio != null)
                {
                    paciente.Domicilio.BajaLogica = true;
                    paciente.Domicilio.FechaBaja = DateTime.Now;
                }
                List<Expression<Func<ExamenComplementario, bool>>> filtroExamenes = new List<Expression<Func<ExamenComplementario, bool>>>();
                filtroExamenes.Add(x => x.Paciente.Id == Id);
                IEnumerable<ExamenComplementario> examenes = _unitOfWork.ExamenesComplementarios.Get(filtroExamenes);
                foreach (ExamenComplementario e in examenes)
                {
                    e.BajaLogica = true;
                    e.FechaBaja = DateTime.Now;
                    _unitOfWork.ExamenesComplementarios.Update(e);
                }

                List<Expression<Func<Ingreso, bool>>> filtroIngreso = new List<Expression<Func<Ingreso, bool>>>();
                filtroIngreso.Add(x => x.Paciente.Id == Id);
                IEnumerable<Ingreso> ingresos = _unitOfWork.Ingresos.Get(filtroIngreso);
                foreach (Ingreso i in ingresos)
                {
                    i.BajaLogica = true;
                    i.FechaBaja = DateTime.Now;

                    List<Expression<Func<Evolucion, bool>>> filtroEvoluciones = new List<Expression<Func<Evolucion, bool>>>();
                    filtroEvoluciones.Add(x => x.Ingreso.Id == Id);
                    IEnumerable<Evolucion> evoluciones = _unitOfWork.Evoluciones.Get(filtroEvoluciones,null, "ExamenFisico");
                    foreach(Evolucion ev in evoluciones)
                    {
                        ev.BajaLogica = true;
                        ev.FechaBaja = DateTime.Now;
                        ev.ExamenFisico.BajaLogica = true;
                        ev.ExamenFisico.FechaBaja = DateTime.Now;
                        _unitOfWork.Evoluciones.Update(ev);
                    }

                    _unitOfWork.Ingresos.Update(i);
                }

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
