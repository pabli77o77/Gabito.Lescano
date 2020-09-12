using System;
using System.Reflection.Metadata.Ecma335;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdSanare.MVC.Controllers
{
    public class PersonaController : Controller
    {
        private IPersonaLogic _logic;

        public PersonaController(IPersonaLogic logic)
        {
            _logic = logic;
        }

        public IActionResult Index()
        {
            try
            {
                return View(_logic.GetAll());
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
        public IActionResult Create(Persona persona)
        {
            try
            {
                _logic.Add(persona);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public ActionResult Details(string documento) 
        {
            Persona persona = _logic.GetByDocument(documento);

            if (persona == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(nameof(Details), persona);
        }
    }
}
