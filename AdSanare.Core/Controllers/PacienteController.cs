using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using AdSanare.Core.Helper;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private IPacienteLogic _logicPaciente;
        private IObraSocialLogic _logicObraSocial;
        private IAuditoriaLogic _auditoriaLogic;
        private IUsuarioLogic _userLogic;

        public PacienteController(IPacienteLogic logicPaciente, IAuditoriaLogic auditoriaLogic, IUsuarioLogic userLogic,IObraSocialLogic logicObraSocial)
        {
            _logicPaciente = logicPaciente;
            _auditoriaLogic = auditoriaLogic;
            _userLogic = userLogic;
            _logicObraSocial = logicObraSocial;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }
        public IActionResult _ListaPacientes(Paciente paciente)
        {
            try
            {
                List<Expression<Func<Paciente, bool>>> filtrosPacientes = new List<Expression<Func<Paciente, bool>>>();
                if (!string.IsNullOrWhiteSpace(paciente.Nombre))
                {
                    filtrosPacientes.Add(p => p.Nombre.Trim().ToUpper().Contains(paciente.Nombre.Trim().ToUpper()));
                }
                if (!string.IsNullOrWhiteSpace(paciente.Apellido))
                {
                    filtrosPacientes.Add(p => p.Apellido.Trim().ToUpper().Contains(paciente.Apellido.Trim().ToUpper()));
                }
                if (!string.IsNullOrWhiteSpace(paciente.Documento))
                {
                    filtrosPacientes.Add(p => p.Documento.Trim().ToUpper().Contains(paciente.Documento.Trim().ToUpper()));
                }
                filtrosPacientes.Add(p=>!p.BajaLogica);
                return PartialView(_logicPaciente.Get(filtrosPacientes));
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }


        public IActionResult Create()
        {
            List<Expression<Func<ObraSocial, bool>>> filtroObraSocial = new List<Expression<Func<ObraSocial, bool>>>();
            filtroObraSocial.Add(p => !p.BajaLogica);
            ViewBag.ObraSocial = _logicObraSocial.Get(filtroObraSocial).Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    _logicPaciente.Add(paciente);
                    SaveAuditoria(paciente);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            List<Expression<Func<ObraSocial, bool>>> filtroObraSocial = new List<Expression<Func<ObraSocial, bool>>>();
            filtroObraSocial.Add(p => !p.BajaLogica);
            ViewBag.ObraSocial = _logicObraSocial.Get(filtroObraSocial).Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]/{iPaciente}")]
        public IActionResult Create([Bind(include: "Nombre,Apellido,Documento,Domicilio,FechaNacimiento,Sexo,EstadoCivil,Telefono,ObraSocial,ObraSocialNumero")] Paciente paciente, string iPaciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicPaciente.Add(paciente);
                    SaveAuditoria(paciente);
                    if (!string.IsNullOrEmpty(iPaciente))
                    {
                        return RedirectToAction("Create", "Ingreso", new { Documento = paciente.Documento });
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(paciente);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            List<Expression<Func<Paciente, bool>>> filtroPaciente = new List<Expression<Func<Paciente, bool>>>();
            filtroPaciente.Add(p => p.Id == id);
            Paciente paciente = _logicPaciente.Get(filtroPaciente, null, "ObraSocial,Domicilio").FirstOrDefault();

            if (paciente == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            ViewBag.ObraSocial = _logicObraSocial.Get().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            return View(paciente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicPaciente.Update(paciente);
                    SaveAuditoria(paciente);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            List<Expression<Func<ObraSocial, bool>>> filtroObraSocial = new List<Expression<Func<ObraSocial, bool>>>();
            filtroObraSocial.Add(p => !p.BajaLogica);
            ViewBag.ObraSocial = _logicObraSocial.Get(filtroObraSocial).Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            return View(paciente);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logicPaciente.Remove(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            List<Expression<Func<Paciente, bool>>> filtroPaciente = new List<Expression<Func<Paciente, bool>>>();
            filtroPaciente.Add(p => p.Id == id);
            Paciente paciente = _logicPaciente.Get(filtroPaciente, null, "ObraSocial,Domicilio").FirstOrDefault();

            if (paciente == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(paciente);
        }
        public ActionResult _BuscarPaciente(string dni)
        {
            if (!string.IsNullOrWhiteSpace(dni))
            {
                List<Expression<Func<Paciente, bool>>> filtroPaciente = new List<Expression<Func<Paciente, bool>>>();
                filtroPaciente.Add(p => p.Documento.Trim().ToUpper().Contains(dni.Trim().ToUpper()));
                filtroPaciente.Add(p => !p.BajaLogica);
                Paciente paciente = _logicPaciente.Get(filtroPaciente).FirstOrDefault();
                if (paciente != null)
                {
                    return PartialView(paciente);
                }
            }
            return PartialView("_NoResult");
        }
        private void SaveAuditoria(Paciente paciente)
        {
            _auditoriaLogic.Add(
                new Auditoria
                {
                    EntidadId = paciente.Id,
                    Entidad = Cypher.Encrypt(JsonSerializer.Serialize(paciente), paciente.GetType().Name),
                    TipoEntidad = paciente.GetType().Name,
                    Usuario = _userLogic.GetByName(User.Identity.Name)
                });
        }

    }
}
