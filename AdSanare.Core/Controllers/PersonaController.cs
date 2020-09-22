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
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }
        public IActionResult _ListaPersonas(Persona model)
        {
            try
            {
                List<Expression<Func<Persona, bool>>> listaWhere = new List<Expression<Func<Persona, bool>>>();
                if (!string.IsNullOrWhiteSpace(model.Nombre))
                {
                    listaWhere.Add(p => p.Nombre.Trim().ToUpper().Contains(model.Nombre.Trim().ToUpper()));
                }
                if (!string.IsNullOrWhiteSpace(model.Apellido))
                {
                    listaWhere.Add(p => p.Apellido.Trim().ToUpper().Contains(model.Apellido.Trim().ToUpper()));
                }
                if (!string.IsNullOrWhiteSpace(model.Documento))
                {
                    listaWhere.Add(p => p.Documento.Trim().ToUpper().Contains(model.Documento.Trim().ToUpper()));
                }
                return PartialView(_logic.Get(listaWhere));
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
