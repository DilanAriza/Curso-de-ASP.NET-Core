using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class EscuelaController: Controller
    {
        private EscuelaContext _context;
        public IActionResult Index()
        {
            ViewBag.CosaDinamica = "La monja";
            var escuela = _context.Escuelas.FirstOrDefault();
            return View(escuela); 
        }
        public EscuelaController(EscuelaContext context)
        {
            _context = context;
        }
    }
}