using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AsignaturaController: Controller
    {
        [Route("Asignatura/")]
        [Route("Asignatura/{asignaturaId}")]
        public IActionResult Index(string asignaturaId)
        {
            if(!String.IsNullOrWhiteSpace(asignaturaId))
            {
                var asignatura = from asig in _context.Asignaturas
                                                where  asig.Id == asignaturaId
                                                select asig;

                return View(asignatura.SingleOrDefault());
            }
            else 
            {
                return View("MultiAsignatura", _context.Asignaturas.ToList()); 
            }
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