using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AsignaturaController: Controller
    {
        public IActionResult Index()
        {
            return View(_context.Asignaturas.FirstOrDefault());
        }

        public IActionResult MultiAsignatura(){

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAsignatura", _context.Asignaturas.ToList()); 
        }
    
        private EscuelaContext _context;
        public AsignaturaController(EscuelaContext context)
        {
           _context = context; 
        }
    }
}