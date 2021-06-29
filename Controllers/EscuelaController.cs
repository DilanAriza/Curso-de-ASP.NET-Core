using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class EscuelaController: Controller
    {
        public IActionResult Index()
        {
            var escuela = new Escuela();
            escuela.AñoDeCreación=2005;
            escuela.UniqueId= Guid.NewGuid().ToString();
            escuela.Nombre="Platzi School";

            ViewBag.CosaDinamica = "La monja";

            return View(escuela); 
        }
    }
}