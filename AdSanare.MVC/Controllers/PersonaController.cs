using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdSanare.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdSanare.MVC.Controllers
{
    public class PersonaController : Controller
    {
        private AdSanareDbContext _context;
        public PersonaController(AdSanareDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persona persona)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {                    
                    await _context.Personas.AddAsync(persona);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
        }
    }
}
