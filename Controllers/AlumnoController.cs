using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AlumnoController: Controller
    {
        public IActionResult Index()
        {

            return View(_context.Alumnos.FirstOrDefault());
        }

        public IActionResult MultiAlumno(){
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiAlumno", _context.Alumnos.ToList()); 
        }
        private EscuelaContext _context;
        public AlumnoController(EscuelaContext context)
        {
           _context = context; 
        }
    }
}