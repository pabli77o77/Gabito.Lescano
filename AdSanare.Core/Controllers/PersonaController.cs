using System;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdSanare.Core.Controllers
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
                return View(_logic.Get());
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
        public IActionResult Create([Bind(include: "Nombre,Apellido,Documento,ObraSocial,ObraSocialNumero,Diagnostico,FechaNacimiento")]Persona persona)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Add(persona);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(persona);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            Persona persona = _logic.Get(id);

            if (persona == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(persona);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "Id,Nombre,Apellido,Documento,ObraSocial,ObraSocialNumero,Diagnostico,FechaNacimiento")] Persona persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Update(persona);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", ex);
            }
            return View(persona);
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
    }
}
