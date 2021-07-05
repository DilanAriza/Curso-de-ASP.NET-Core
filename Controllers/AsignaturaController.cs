using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AsignaturaController: Controller
    {
        #region Variables
        private EscuelaContext _context;

        #endregion
        
        #region Constructor
        public AsignaturaController(EscuelaContext context)
        {
           _context = context; 
        }

        #endregion

        // Controllers
        #region Controllers

        [Route("asignatura/")]
        [HttpGet]
        public IActionResult Index(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            return View("MultiAsignatura", _context.Asignaturas.ToList());
        }

        
        [Route("asignatura/{id}")]
        [HttpGet]
        public IActionResult GetOne(string id)
        {
            ViewBag.Fecha = DateTime.Now;
            if(!String.IsNullOrWhiteSpace(id))
            {
                var asignatura = from asig in _context.Asignaturas
                                                where  asig.Id == id
                                                select asig;

                return View("Index", asignatura.SingleOrDefault());
            }
            else 
            {
                return RedirectToAction("Index");
            }
        }

        // [GET(/create)] - create new asignatura
        [Route("asignatura/create")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Fecha = DateTime.Now;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignaruta){
            ViewBag.Fecha = DateTime.Now;

            if(ModelState.IsValid)
            {
                var curso = _context.Cursos.FirstOrDefault();
                asignaruta.CursoId = curso.Id;

                _context.Asignaturas.Add(asignaruta);
                _context.SaveChanges();

                ViewBag.mensaje = "Asignatura creada";

                return View("MultiAsignatura", _context.Asignaturas.ToList());
            }
            else
            {
                return View(asignaruta);
            }
        }
        #endregion
    }
}