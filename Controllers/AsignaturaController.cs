using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AsignaturaController: Controller
    {
        public IActionResult Index()
        {
            var asignatura = new Asignatura{
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Programación"
            };

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View(asignatura); 
        }
    }
}