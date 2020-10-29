using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static AdSanare.Core.Areas.Identity.Pages.Account.RegisterModel;

namespace AdSanare.Core.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly AdSanareUsuariosDbContext _context;
        private readonly IUsuarioLogic _logic;
        private readonly ILogger<HomeController> _logger;

        public UsuariosController(UserManager<Usuario> userManager,IUsuarioLogic logic,AdSanareUsuariosDbContext context, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _logic = logic;
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(_logic.Get());
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
                        NormalizedUserName = user.UserName.ToUpper(),
                        Name=user.Name,
                        LastName=user.LastName,
                        EmployeeFileNumber=Convert.ToInt32(user.EmployeeFileNumber),
                        PhoneNumber = user.PhoneNumber,
                        PasswordHash = _userManager.PasswordHasher.HashPassword(Usuario, user.Password),
                        EmailConfirmed=true,
                        PhoneNumberConfirmed=true,
                        LockoutEnabled = false
                    };
                    IdentityResult result = await _userManager.CreateAsync(Usuario, user.Password);
                    if (result.Succeeded)
                    {
                        _logger.Log(LogLevel.Information, "Usuario creado", result);
                        return RedirectToAction(nameof(Index));
                    }

                    foreach (IdentityError error in result.Errors)
                    {
                        // Si ingreso una contraseña sin las condiciones necesarias,
                        // no muestra el error en los inputs.
                        _logger.Log(LogLevel.Error, "No se pudo crear nuevo uusario", result);
                        ModelState.AddModelError("", error.Description);
                    }
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
            try
            {
                var Usuario = _logic.Get(Id);
                _logger.Log(LogLevel.Information, $"Usuario {Usuario.UserName} encontrado", Usuario);
                return View(Usuario);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Error al obtener el usuario", ex);
                return View("Error", ex);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Usuario = _logic.Get(user.Id);
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
                    _logic.Update(Usuario);
                    _logger.Log(LogLevel.Information, "Usuario editado correctamente", Usuario.Id);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Error al editar el usuario", ex);
                return RedirectToAction("Error", ex);
            }
            return View(user);
        }
    }
}
