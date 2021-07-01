using Microsoft.AspNetCore.Mvc;
using Curso_de_ASP.NET_Core.Models;
using System.Collections.Generic;
using System;

namespace Curso_de_ASP.NET_Core.Controllers
{
    public class AsignaturaController: Controller
    {
        public IActionResult Index()
        {

            return View(new Asignatura{
                    Nombre="Programación",
                }
            );
        }

        public IActionResult MultiAsignatura(){
            var listaAsignaturas = new List<Asignatura>()
            {
                new Asignatura{
                    Nombre = "Matemáticas",
                },
                new Asignatura{
                    Nombre = "Educación Física",
                },
                new Asignatura{
                    Nombre = "Castellano",
                },
                new Asignatura{
                    Nombre = "Ciencias Naturales",
                },
                new Asignatura{
                    Nombre = "Programacion",
                },
            };

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View(listaAsignaturas); 
        }
    
        public AsignaturaController(EscuelaContext context)
        {
            
        }
    }
}