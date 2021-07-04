using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{

    public class CursoController: Controller
    {

        private EscuelaContext _context;
        public CursoController(EscuelaContext context)
        {
           _context = context; 
        }

        [Route("Curso")]
        [HttpGet]
        public IActionResult Index(string id)
        {
            return View("MultiCurso",  _context.Cursos.ToList());
        }

        [Route("Curso/{id}")]
        [HttpGet]
        public IActionResult GetOne(string id)
        {
            if(!String.IsNullOrWhiteSpace(id))
            {
                var curso = from curs in _context.Cursos
                                                where  curs.Id == id
                                                select curs;
                return View("Index",curso.SingleOrDefault());
            }
            else 
            {
                return RedirectToAction("Index");
            }
        }

        [Route("Curso/create")]
        [HttpGet]
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
                
                return View("GetOne", curso);
            }
            else
            {
                return View(curso);
            } 
        }
    }
}