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
    public class PacienteController : Controller
    {
        private IPacienteLogic _logic;

        public PacienteController(IPacienteLogic logic)
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
        public IActionResult _ListaPacientes(Paciente model)
        {
            try
            {
                List<Expression<Func<Paciente, bool>>> listaWhere = new List<Expression<Func<Paciente, bool>>>();
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
        public IActionResult Create([Bind(include: "Nombre,Apellido,Documento,FechaNacimiento,Sexo,EstadoCivil,Telefono,ObraSocialNumero")] Paciente model)
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
            Paciente model = _logic.Get(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "Id,Nombre,Apellido,Documento,FechaNacimiento,Sexo,EstadoCivil,Telefono,ObraSocialNumero")] Paciente model)
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
            Paciente model = _logic.Get(id);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("NotFound");
            }

            return PartialView(model);
        }
    }
}
