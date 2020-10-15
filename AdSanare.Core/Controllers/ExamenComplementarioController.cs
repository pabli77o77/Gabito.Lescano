using System;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class ExamenComplementarioController : Controller
    {
        private IExamenComplementarioLogic _logic;
        public ExamenComplementarioController(IExamenComplementarioLogic logic)
        {
            _logic = logic;
        }

        public IActionResult Index()
        {
            try
            {
                return View(_logic.Get());
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
        public IActionResult Create(ExamenComplementario model)
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
            ExamenComplementario model = _logic.Get(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamenComplementario model)
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
            ExamenComplementario model = _logic.Get(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(model);
        }
    }
}
