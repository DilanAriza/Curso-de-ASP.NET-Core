using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        
        [Required(ErrorMessage ="El nombre del alumno es requerido")]
        [MinLength(10, ErrorMessage ="El nombre del alumno no puede ser menor a 10")]
        [Display(Prompt="Nombre del alumno", Name ="Nombre alumno")]
        public override string Nombre {get; set;}
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}