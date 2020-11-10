using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using AdSanare.Core.Helper;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class EvolucionController : Controller
    {
        private IEvolucionLogic _logicEvolucion;
        private IAuditoriaLogic _auditoriaLogic;
        private IUsuarioLogic _userLogic;

        public EvolucionController(IEvolucionLogic logicEvolucion, IAuditoriaLogic auditoriaLogic, IUsuarioLogic userLogic)
        {
            _logicEvolucion = logicEvolucion;
            _auditoriaLogic = auditoriaLogic;
            _userLogic = userLogic;
        }

        public IActionResult Index(int IngresoId)
        {
            try
            {
                List<Expression<Func<Evolucion, bool>>> filtroIngreso = new List<Expression<Func<Evolucion, bool>>>();
                filtroIngreso.Add(p => p.Ingreso.Id == IngresoId);
                filtroIngreso.Add(p => !p.BajaLogica);
                ViewBag.IngresoId = IngresoId;
                return PartialView(_logicEvolucion.Get(filtroIngreso, null, "ServicioInternacion,CamaInternacion,Ingreso,Ingreso.Paciente"));
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public IActionResult Create(int IngresoId)
        {
            ViewBag.Servicios=_logicEvolucion.GetServicios().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.Camas= _logicEvolucion.GetCamas().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.IngresoId = IngresoId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Evolucion evolucion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicEvolucion.Add(evolucion);
                    SaveAuditoria(evolucion);
                    return RedirectToAction("Index","Ingreso");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            ViewBag.Servicios = _logicEvolucion.GetServicios().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.Camas = _logicEvolucion.GetCamas().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.IngresoId = evolucion.Ingreso.Id;
            return View(evolucion);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Expression<Func<Evolucion, bool>>> filtroEvolucion = new List<Expression<Func<Evolucion, bool>>>();
            filtroEvolucion.Add(p => p.Id == id);
            Evolucion evolucion = _logicEvolucion.Get(filtroEvolucion, null, "ServicioInternacion,CamaInternacion,Ingreso,ExamenFisico").FirstOrDefault();
            if (evolucion == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            ViewBag.Servicios = _logicEvolucion.GetServicios().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.Camas = _logicEvolucion.GetCamas().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            return View(evolucion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evolucion evolucion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicEvolucion.Update(evolucion);
                    SaveAuditoria(evolucion);
                    return RedirectToAction("Index", "Ingreso");
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            ViewBag.Servicios = _logicEvolucion.GetServicios().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.Camas = _logicEvolucion.GetCamas().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            return View(evolucion);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logicEvolucion.Remove(Id);
                return RedirectToAction("Index","Ingreso");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            List<Expression<Func<Evolucion, bool>>> filtroEvolucion = new List<Expression<Func<Evolucion, bool>>>();
            filtroEvolucion.Add(p => p.Id == id);
            Evolucion evolucion = _logicEvolucion.Get(filtroEvolucion, null, "ServicioInternacion,CamaInternacion,Ingreso,Ingreso.Paciente,ExamenFisico").FirstOrDefault();

            if (evolucion == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(evolucion);
        }

        [HttpGet]
        public ActionResult PDF(int id)
        {
            List<Expression<Func<Evolucion, bool>>> filtroEvolucion = new List<Expression<Func<Evolucion, bool>>>();
            filtroEvolucion.Add(p => p.Ingreso.Id == id);
            return new ViewAsPdf("../PDF/PDF", _logicEvolucion.Get(filtroEvolucion, null, "ServicioInternacion,CamaInternacion,Ingreso,Ingreso.Paciente,ExamenFisico")) {
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                PageMargins = new Margins(10, 10, 10, 10)
            };
        }

        private void SaveAuditoria(Evolucion evolucion)
        {
            _auditoriaLogic.Add(
                new Auditoria
                {
                    EntidadId = evolucion.Id,
                    Entidad = Cypher.Encrypt(JsonSerializer.Serialize(evolucion),evolucion.GetType().Name),
                    TipoEntidad = evolucion.GetType().Name,
                    Usuario = _userLogic.GetByName(User.Identity.Name)
                });
        }
    }
}
