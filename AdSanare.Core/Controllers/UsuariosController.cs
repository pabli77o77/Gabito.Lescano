using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdSanare.Context;
using AdSanare.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static AdSanare.Core.Areas.Identity.Pages.Account.RegisterModel;

namespace AdSanare.Core.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly AdSanareUsuariosDbContext _context;
        public UsuariosController(UserManager<Usuario> userManager,AdSanareUsuariosDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Usuario> usuarios = _context.Users.ToList();
            return View(usuarios);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InputModel user)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Usuario Usuario = new Usuario();
                    Usuario = new Usuario
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        NormalizedEmail = user.Email.ToUpper(),
                        NormalizedUserName = user.Email.ToUpper(),
                        Name=user.Name,
                        LastName=user.LastName,
                        EmployeeFileNumber=Convert.ToInt32(user.EmployeeFileNumber),
                        PhoneNumber = user.PhoneNumber,
                        PasswordHash = _userManager.PasswordHasher.HashPassword(Usuario, user.Password),
                        EmailConfirmed=true,
                        PhoneNumberConfirmed=true,
                        LockoutEnabled = false
                    };
                    await _userManager.CreateAsync(Usuario, user.Password);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(user);            
        }
        [HttpGet]
        public IActionResult Edit(string Id)
        {
            var Usuario = _context.Users.Find(Id);
            return View(Usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Usuario = _context.Users.Find(user.Id);
                    Usuario.UserName = user.UserName;
                    Usuario.Email = user.Email;
                    Usuario.NormalizedEmail = user.Email.ToUpper();
                    Usuario.NormalizedUserName = user.Email.ToUpper();
                    Usuario.Name = user.Name;
                    Usuario.LastName = user.LastName;
                    Usuario.EmployeeFileNumber = Convert.ToInt32(user.EmployeeFileNumber);
                    Usuario.PhoneNumber = user.PhoneNumber;
                    Usuario.PasswordHash = _userManager.PasswordHasher.HashPassword(Usuario, user.PasswordHash);
                    Usuario.EmailConfirmed = true;
                    Usuario.PhoneNumberConfirmed = true;
                    Usuario.LockoutEnabled = false;
                    _context.Users.Update(Usuario);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", ex);
            }
            return View(user);
        }
    }
}
