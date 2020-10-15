using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class EvolucionController : Controller
    {
        private IEvolucionLogic _logic;
        public EvolucionController(IEvolucionLogic logic)
        {
            _logic = logic;
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


    }
}
