using System;
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
            return View(_logic.GetAll());
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
    }
}
