using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class CamaController : Controller
    {
        private ICamaLogic _logicCama;

        public CamaController(ICamaLogic logicCama)
        {
            _logicCama = logicCama;
        }
        public IActionResult Index(int ServicioId)
        {
            try
            {
                List<Expression<Func<Cama, bool>>> filtroCama = new List<Expression<Func<Cama, bool>>>();
                filtroCama.Add(p => p.ServicioInternacion.Id==ServicioId);
                filtroCama.Add(p => !p.BajaLogica);
                ViewBag.ServicioId = ServicioId;
                return PartialView(_logicCama.Get(filtroCama));
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public IActionResult Create(int ServicioId)
        {
            ViewBag.ServicioId = ServicioId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cama cama)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicCama.Add(cama);
                    return RedirectToAction("Index", "Servicio");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            ViewBag.ServicioId = cama.ServicioInternacion.Id;
            return View(cama);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cama cama = _logicCama.Get(id);

            if (cama == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(cama);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cama cama)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicCama.Update(cama);
                    return RedirectToAction("Index", "Servicio");
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            return View(cama);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logicCama.Remove(Id);
                return RedirectToAction("Index", "Servicio");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
        }
    }
}
