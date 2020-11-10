using AdSanare.Core.Helper;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class IngresoController : Controller
    {
        private IIngresoLogic _logicIngreso;
        private IAuditoriaLogic _auditoriaLogic;
        private IUsuarioLogic _userLogic;

        public IngresoController(IIngresoLogic logicIngreso, IAuditoriaLogic auditoriaLogic, IUsuarioLogic userLogic)
        {
            _logicIngreso = logicIngreso;
            _auditoriaLogic = auditoriaLogic;
            _userLogic = userLogic;
        }

        public IActionResult Index()
        {
            try
            {
                List<Expression<Func<Ingreso, bool>>> filtroIngreso = new List<Expression<Func<Ingreso, bool>>>();
                filtroIngreso.Add(p => p.FechaEgreso==null && !p.Defuncion);         
                filtroIngreso.Add(p => !p.BajaLogica);         
                return View(_logicIngreso.Get(filtroIngreso,null,"Paciente"));
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
        public IActionResult Create(string Documento)
        {
            ViewBag.Documento = null;
            if (!String.IsNullOrWhiteSpace(Documento))
            {
                ViewBag.Documento = Documento;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingreso ingreso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ingreso.Paciente != null)
                    {
                        _logicIngreso.Add(ingreso);
                        SaveAuditoria(ingreso);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(ingreso);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Ingreso ingreso = _logicIngreso.Get(id);

            if (ingreso == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(ingreso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ingreso ingreso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicIngreso.Update(ingreso);
                    SaveAuditoria(ingreso);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            return View(ingreso);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logicIngreso.Remove(Id);
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
            List<Expression<Func<Ingreso, bool>>> filtroIngreso = new List<Expression<Func<Ingreso, bool>>>();
            filtroIngreso.Add(p => p.Id==id);
            Ingreso ingreso = _logicIngreso.Get(filtroIngreso, null, "Paciente").FirstOrDefault();

            if (ingreso == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(ingreso);
        }

        private void SaveAuditoria(Ingreso ingreso)
        {
            _auditoriaLogic.Add(
                new Auditoria
                {
                    EntidadId = ingreso.Id,
                    Entidad = Cypher.Encrypt(JsonSerializer.Serialize(ingreso), ingreso.GetType().Name),
                    TipoEntidad = ingreso.GetType().Name,
                    Usuario = _userLogic.GetByName(User.Identity.Name)
                });
        }

    }
}
