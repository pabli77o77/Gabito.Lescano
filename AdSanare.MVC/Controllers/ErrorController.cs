using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AdSanare.MVC.Controllers
{
    public class ErrorController : Controller
    {
    [Route("Error/{statuscode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            
            switch (statusCode)
            {
                case (int)HttpStatusCode.NotFound:
                    ViewBag.ErrorMessage = "Página no encontrada.";
                    break;
                case (int)HttpStatusCode.BadRequest:
                    ViewBag.ErrorMessage = "Error de respuesta del servidor.";
                    break;
                case (int)HttpStatusCode.Forbidden:
                    ViewBag.ErrorMessage = "Error de prohibición de la solicitud.";
                    break;
                case (int)HttpStatusCode.Conflict:
                    ViewBag.ErrorMessage = "La solicitud no se pudo realizar debido a un conflicto en el servidor.";
                    break;
                default:
                    ViewBag.ErrorMessage = $"Se produjo un error HTTP {statusCode} al procesar la solicitud.";
                    break;
            }
            return View("NotFound");
        }
    }
}
