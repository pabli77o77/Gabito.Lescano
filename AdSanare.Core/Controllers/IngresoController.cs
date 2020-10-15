using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class IngresoController : Controller
    {
        private IIngresoLogic _logic;

        public IngresoController(IIngresoLogic logic)
        {
            _logic = logic;
        }

        public IActionResult Index()
        {
            try
            {
                List<Expression<Func<Ingreso, bool>>> listaWhere = new List<Expression<Func<Ingreso, bool>>>();
                listaWhere.Add(p => p.FechaEgreso==null && !p.Defuncion);         
                return View(_logic.Get(listaWhere,null,"Paciente"));
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
        public IActionResult Create(Ingreso model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Add(model);
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
        public ActionResult Edit(int id)
        {
            Ingreso model = _logic.Get(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ingreso model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Update(model);
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
            List<Expression<Func<Ingreso, bool>>> listaWhere = new List<Expression<Func<Ingreso, bool>>>();
            listaWhere.Add(p => p.Id==id);
            Ingreso model = _logic.Get(listaWhere, null, "Paciente").FirstOrDefault();

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(model);
        }

    }
}
