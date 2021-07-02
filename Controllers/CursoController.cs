using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class CursoController: Controller
    {
        [Route("curso/")]
        [Route("curso/{id}")]
        public IActionResult Index(string id)
        {
            if(!String.IsNullOrWhiteSpace(id))
            {
                var curso = from curs in _context.Cursos
                                                where  curs.Id == id
                                                select curs;
                return View(curso.SingleOrDefault());
            }
            else 
            {
                return View("MultiCurso",  _context.Cursos.ToList()); 
            }
        }
        public IActionResult MultiCurso(){
            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View("MultiCurso", _context.Cursos.ToList()); 
        }

        public IActionResult Create(){
            ViewBag.Fecha = DateTime.Now;

            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Curso curso){
            ViewBag.Fecha = DateTime.Now;

            if(ModelState.IsValid)
            {
                var escuela = _context.Escuelas.FirstOrDefault();
                curso.EscuelaId = escuela.Id;

                _context.Cursos.Add(curso);
                _context.SaveChanges();

                ViewBag.mensaje = "Curso creado";
                
                return View("Index", curso);
            }
            else
            {
                return View(curso);
            } 
        }

        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
           _context = context; 
        }
    }
}