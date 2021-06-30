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
                    UniqueId= Guid.NewGuid().ToString()
                }
            );
        }

        public IActionResult MultiAsignatura(){
            var listaAsignaturas = new List<Asignatura>()
            {
                new Asignatura{
                    Nombre = "Matemáticas",
                    UniqueId = Guid.NewGuid().ToString()
                },
                new Asignatura{
                    Nombre = "Educación Física",
                    UniqueId = Guid.NewGuid().ToString()
                },
                new Asignatura{
                    Nombre = "Castellano",
                    UniqueId = Guid.NewGuid().ToString()
                },
                new Asignatura{
                    Nombre = "Ciencias Naturales",
                    UniqueId = Guid.NewGuid().ToString()
                },
                new Asignatura{
                    Nombre = "Programacion",
                    UniqueId = Guid.NewGuid().ToString()
                },
            };

            ViewBag.CosaDinamica = "La monja";
            ViewBag.Fecha = DateTime.Now;

            return View(listaAsignaturas); 
        }
    }
}