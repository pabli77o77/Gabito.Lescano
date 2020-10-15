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
        private ICamaLogic _logic;

        public CamaController(ICamaLogic logic)
        {
            _logic = logic;
        }
        public IActionResult Index(int ServicioId)
        {
            try
            {
                List<Expression<Func<Cama, bool>>> listaWhere = new List<Expression<Func<Cama, bool>>>();
                listaWhere.Add(p => p.ServicioInternacion.Id==ServicioId);
                ViewBag.ServicioId = ServicioId;
                return PartialView(_logic.Get(listaWhere));
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
        public IActionResult Create(Cama model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Add(model);
                    return RedirectToAction("Index", "Servicio");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            ViewBag.ServicioId = model.ServicioInternacion.Id;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cama model = _logic.Get(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cama model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Update(model);
                    return RedirectToAction("Index", "Servicio");
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
                return RedirectToAction("Index", "Servicio");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
        }
    }
}
