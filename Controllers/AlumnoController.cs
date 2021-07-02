using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AlumnoController: Controller
    {
        [Route("alumno/")]
        [Route("alumno/{id}")]
        public IActionResult Index(string id)
        {
            if(!String.IsNullOrWhiteSpace(id))
            {
                var alumno = from alum in _context.Alumnos
                                                where  alum.Id == id
                                                select alum;
                return View(alumno.SingleOrDefault());
            }
            else 
            {
                return View("MultiAlumno",  _context.Alumnos.ToList()); 
            }
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