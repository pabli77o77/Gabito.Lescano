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
    public class ObraSocialController : Controller
    {
        private IObraSocialLogic _logicObraSocial;

        public ObraSocialController(IObraSocialLogic logicObraSocial)
        {
            _logicObraSocial = logicObraSocial;
        }

        public IActionResult Index()
        {
            try
            {
                List<Expression<Func<ObraSocial, bool>>> filtroObraSocial = new List<Expression<Func<ObraSocial, bool>>>();
                filtroObraSocial.Add(p => !p.BajaLogica);
                return View(_logicObraSocial.Get(filtroObraSocial));
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
        public IActionResult Create(ObraSocial obraSocial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicObraSocial.Add(obraSocial);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(obraSocial);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ObraSocial obraSocial = _logicObraSocial.Get(id);

            if (obraSocial == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(obraSocial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ObraSocial obraSocial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logicObraSocial.Update(obraSocial);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            return View(obraSocial);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logicObraSocial.Remove(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
        }
    }
}
