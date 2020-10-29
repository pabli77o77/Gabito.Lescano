using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
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
        private IEvolucionLogic _logic;
        private IAuditoriaLogic _auditoriaLogic;
        private IUsuarioLogic _userLogic;

        public EvolucionController(IEvolucionLogic logic, IAuditoriaLogic auditoriaLogic, IUsuarioLogic userLogic)
        {
            _logic = logic;
            _auditoriaLogic = auditoriaLogic;
            _userLogic = userLogic;
        }

        public IActionResult Index(int IngresoId)
        {
            try
            {
                List<Expression<Func<Evolucion, bool>>> listaWhere = new List<Expression<Func<Evolucion, bool>>>();
                listaWhere.Add(p => p.Ingreso.Id == IngresoId);
                ViewBag.IngresoId = IngresoId;
                return PartialView(_logic.Get(listaWhere,null, "ServicioInternacion,CamaInternacion,Ingreso,Ingreso.Paciente"));
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public IActionResult Create(int IngresoId)
        {
            ViewBag.Servicios=_logic.GetServicios().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.Camas= _logic.GetCamas().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.IngresoId = IngresoId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Evolucion model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Add(model);
                    SaveAuditoria(model);
                    return RedirectToAction("Index","Ingreso");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            ViewBag.Servicios = _logic.GetServicios().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.Camas = _logic.GetCamas().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.IngresoId = model.Ingreso.Id;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Expression<Func<Evolucion, bool>>> listaWhere = new List<Expression<Func<Evolucion, bool>>>();
            listaWhere.Add(p => p.Id == id);
            Evolucion model = _logic.Get(listaWhere, null, "ServicioInternacion,CamaInternacion,Ingreso,ExamenFisico").FirstOrDefault();
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }
            ViewBag.Servicios = _logic.GetServicios().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.Camas = _logic.GetCamas().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evolucion model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Update(model);
                    SaveAuditoria(model);
                    return RedirectToAction("Index", "Ingreso");
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            ViewBag.Servicios = _logic.GetServicios().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            ViewBag.Camas = _logic.GetCamas().Select(g => new SelectListItem() { Text = g.Descripcion, Value = g.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logic.Remove(Id);
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
            List<Expression<Func<Evolucion, bool>>> listaWhere = new List<Expression<Func<Evolucion, bool>>>();
            listaWhere.Add(p => p.Id == id);
            Evolucion model = _logic.Get(listaWhere, null, "ServicioInternacion,CamaInternacion,Ingreso,Ingreso.Paciente,ExamenFisico").FirstOrDefault();

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult PDF(int id)
        {
            List<Expression<Func<Evolucion, bool>>> listaWhere = new List<Expression<Func<Evolucion, bool>>>();
            listaWhere.Add(p => p.Ingreso.Id == id);
            return new ViewAsPdf("../PDF/PDF", _logic.Get(listaWhere, null, "ServicioInternacion,CamaInternacion,Ingreso,Ingreso.Paciente,ExamenFisico")) {
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                PageMargins = new Margins(10, 10, 10, 10)
            };
        }

        private void SaveAuditoria(Evolucion model)
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
