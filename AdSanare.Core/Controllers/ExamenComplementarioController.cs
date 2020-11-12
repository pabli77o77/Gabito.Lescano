using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;
using AdSanare.Core.Helper;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class ExamenComplementarioController : Controller
    {
        private IExamenComplementarioLogic _logicExamen;
        private IAuditoriaLogic _auditoriaLogic;
        private IUsuarioLogic _userLogic;

        public ExamenComplementarioController(IExamenComplementarioLogic logicExamen,IAuditoriaLogic auditoriaLogic,IUsuarioLogic userLogic)
        {
            _logicExamen = logicExamen;
            _auditoriaLogic = auditoriaLogic;
            _userLogic = userLogic;
        }

        public IActionResult Index()
        {
            try
            {
                List<Expression<Func<ExamenComplementario, bool>>> filtroExamen = new List<Expression<Func<ExamenComplementario, bool>>>();
                filtroExamen.Add(p => !p.BajaLogica);
                return View(_logicExamen.Get(filtroExamen,null,"Paciente"));
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
        public IActionResult Create(ExamenComplementario examenComplementario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicExamen.Add(examenComplementario);
                    SaveAuditoria(examenComplementario);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(examenComplementario);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ExamenComplementario examenComplementario = _logicExamen.Get(id);

            if (examenComplementario == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(examenComplementario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamenComplementario examenComplementario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicExamen.Update(examenComplementario);
                    SaveAuditoria(examenComplementario);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            return View(examenComplementario);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logicExamen.Remove(Id);
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
            ExamenComplementario examenComplementario = _logicExamen.Get(id);

            if (examenComplementario == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(examenComplementario);
        }

        private void SaveAuditoria(ExamenComplementario examenComplementario)
        {
            _auditoriaLogic.Add(
                new Auditoria
                {
                    EntidadId = examenComplementario.Id,
                    Entidad = Cypher.Encrypt(JsonSerializer.Serialize(examenComplementario), examenComplementario.GetType().Name),
                    TipoEntidad = examenComplementario.GetType().Name,
                    Usuario = _userLogic.GetByName(User.Identity.Name)
                });
        }

    }
}
