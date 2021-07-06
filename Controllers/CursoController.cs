using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{

    public class CursoController: Controller
    {

        #region Variables
        private EscuelaContext _context;

        #endregion
        
        #region Constructor
        public CursoController(EscuelaContext context)
        {
           _context = context; 
        }

        #endregion

        #region Controllers

        // [GET] - index
        [Route("Curso")]
        [HttpGet]
        public IActionResult Index()
        {
            
            ViewBag.Fecha = DateTime.Now;
            return View("MultiCurso",  _context.Cursos.ToList());
        }

        // [GET({id})] - index
        [Route("Curso/{id}")]
        [HttpGet]
        public IActionResult GetOne(string id)
        {
            
            ViewBag.Fecha = DateTime.Now;
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

        // [GET(/create)] - index
        [Route("Curso/create")]
        [HttpGet]
        public IActionResult Create(){
            ViewBag.Fecha = DateTime.Now;
            return View(); 
        }

        // [POST(/create)] - index
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
                
                return View("MultiCurso", _context.Cursos.ToList());
            }
            else
            {
                return View(curso);
            } 
        }
        
        // [GET(/edit/{Id})] - Delete Curso
        [Route("Curso/edit/{Id}")]
        [HttpGet]
        public IActionResult Edit(String id)
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        // [GET(/edit/{Id})] - Delete Curso
        [Route("Curso/edit/{Id}")]
        [HttpPost]
        public IActionResult Edit(Curso curso ,String id)
        {
            
            ViewBag.Fecha = DateTime.Now;
            if(!String.IsNullOrWhiteSpace(id))
            {
                var cursoInDb = _context.Cursos.Where(c => c.Id == id).First();
                if(cursoInDb != null)
                {
                    cursoInDb.Nombre = curso.Nombre;
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
        
        // [GET(/delete/{Id})] - Delete Curso
        [Route("Curso/delete/{Id}")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            if(!String.IsNullOrWhiteSpace(id))
            {
                var curso = _context.Cursos.FirstOrDefault(c => c.Id == id);
                if(curso != null)
                {   
                    _context.Cursos.Remove(curso);
                    _context.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }
        #endregion
    }
}