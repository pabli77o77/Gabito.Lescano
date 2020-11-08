using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private IPacienteLogic _logic;
        private IAuditoriaLogic _auditoriaLogic;
        private IUsuarioLogic _userLogic;

        public PacienteController(IPacienteLogic logic, IAuditoriaLogic auditoriaLogic, IUsuarioLogic userLogic)
        {
            _logic = logic;
            _auditoriaLogic = auditoriaLogic;
            _userLogic = userLogic;
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
        public IActionResult _ListaPacientes(Paciente model)
        {
            try
            {
                List<Expression<Func<Paciente, bool>>> listaWhere = new List<Expression<Func<Paciente, bool>>>();
                if (!string.IsNullOrWhiteSpace(model.Nombre))
                {
                    listaWhere.Add(p => p.Nombre.Trim().ToUpper().Contains(model.Nombre.Trim().ToUpper()));
                }
                if (!string.IsNullOrWhiteSpace(model.Apellido))
                {
                    listaWhere.Add(p => p.Apellido.Trim().ToUpper().Contains(model.Apellido.Trim().ToUpper()));
                }
                if (!string.IsNullOrWhiteSpace(model.Documento))
                {
                    listaWhere.Add(p => p.Documento.Trim().ToUpper().Contains(model.Documento.Trim().ToUpper()));
                }
                return PartialView(_logic.Get(listaWhere));
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(include: "Nombre,Apellido,Documento,FechaNacimiento,Sexo,EstadoCivil,Telefono,ObraSocialNumero")] Paciente model)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Add(model);
                    SaveAuditoria(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]/{iPaciente}")]
        public IActionResult Create([Bind(include: "Nombre,Apellido,Documento,FechaNacimiento,Sexo,EstadoCivil,Telefono,ObraSocialNumero")] Paciente model, string iPaciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Add(model);
                    SaveAuditoria(model);
                    if (!string.IsNullOrEmpty(iPaciente))
                    {
                        return RedirectToAction("Create", "Ingreso", new { Documento = model.Documento });
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
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            Paciente model = _logic.Get(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "Id,Nombre,Apellido,Documento,FechaNacimiento,Sexo,EstadoCivil,Telefono,ObraSocialNumero")] Paciente model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Update(model);
                    SaveAuditoria(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logic.Remove(Id);
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
            Paciente model = _logic.Get(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(model);
        }
        public ActionResult _BuscarPaciente(string dni)
        {
            if (!string.IsNullOrWhiteSpace(dni))
            {
                List<Expression<Func<Paciente, bool>>> listaWhere = new List<Expression<Func<Paciente, bool>>>();
                listaWhere.Add(p => p.Documento.Trim().ToUpper().Contains(dni.Trim().ToUpper()));
                Paciente model = _logic.Get(listaWhere).FirstOrDefault();
                if (model != null)
                {
                    return PartialView(model);
                }
            }
            return PartialView("_NoResult");
        }
        private void SaveAuditoria(Paciente model)
        {
            _auditoriaLogic.Add(
                new Auditoria
                {
                    EntidadId = model.Id,
                    Entidad = JsonSerializer.Serialize(model),
                    TipoEntidad = model.GetType().Name,
                    Usuario = _userLogic.GetByName(User.Identity.Name)
                });
        }

    }
}
