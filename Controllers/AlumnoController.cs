using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AlumnoController: Controller
    {
        #region Variables
        private EscuelaContext _context;

        #endregion
        
        #region Constructor
        public AlumnoController(EscuelaContext context)
        {
           _context = context; 
        }

        #endregion

        // Controllers
        #region Controllers

        // [GET] - index
        [Route("alumno/")]
        [HttpGet]
        public IActionResult Index(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAlumno",  _context.Alumnos.ToList()); 
        }

        // [GET({id})] - index
        [Route("alumno/{id}")]
        [HttpGet]
        public IActionResult GetOne(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            if(!String.IsNullOrWhiteSpace(id))
            {
                var alumno = from alum in _context.Alumnos
                                            where alum.Id == 
                                            id
                                            select alum;
                return View("Index", alumno.SingleOrDefault());
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // [GET(/create)] - index
        [Route("alumno/create")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        // [POST(/create)] - index
        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            ViewBag.Fecha = DateTime.Now;
            if(ModelState.IsValid)
            {
                var curso = _context.Cursos.FirstOrDefault();
                alumno.CursoId = curso.Id;

                _context.Alumnos.Add(alumno);
                _context.SaveChanges();
                
                ViewBag.mensaje = "Alumno Creado";

                return RedirectToAction("Index");
            }
            else
            {
                return View(alumno);
            }
        }

         // [GET(/edit/{Id})] - Delete Curso
        [Route("alumno/edit/{Id}")]
        [HttpGet]
        public IActionResult Edit(String id)
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        // [GET(/edit/{Id})] - Delete Curso
        [Route("alumno/edit/{Id}")]
        [HttpPost]
        public IActionResult Edit(Alumno alumno ,String id)
        {
            
            ViewBag.Fecha = DateTime.Now;
            if(!String.IsNullOrWhiteSpace(id))
            {
                var AlumnoInDb = _context.Alumnos.Where(a => a.Id == id).First();
                if(AlumnoInDb != null)
                {
                    AlumnoInDb.Nombre = alumno.Nombre;
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        // [GET(/delete/{Id})] - Delete Alumno
        [Route("alumno/delete/{id}")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            if(!String.IsNullOrWhiteSpace(id))
            {
                var alumno = _context.Alumnos.FirstOrDefault(a => a.Id == id);
                if(alumno != null)
                {
                    _context.Alumnos.Remove(alumno);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}