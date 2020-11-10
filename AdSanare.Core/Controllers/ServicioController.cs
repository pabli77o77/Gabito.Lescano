using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class ServicioController : Controller
    {
        private IServicioLogic _logicServicio;

        public ServicioController(IServicioLogic logicServicio)
        {
            _logicServicio = logicServicio;
        }

        public IActionResult Index()
        {
            try
            {
                List<Expression<Func<Servicio, bool>>> filtroServicio = new List<Expression<Func<Servicio, bool>>>();
                filtroServicio.Add(p => !p.BajaLogica);
                return View(_logicServicio.Get(filtroServicio));
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
        public IActionResult Create(Servicio servicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicServicio.Add(servicio);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(servicio);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Servicio servicio = _logicServicio.Get(id);

            if (servicio == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(servicio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Servicio servicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicServicio.Update(servicio);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            return View(servicio);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logicServicio.Remove(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
        }
    }
}
