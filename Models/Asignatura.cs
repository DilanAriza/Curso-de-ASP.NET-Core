using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        
        [Required(ErrorMessage="Se requiere un nombre para la asignatura")]
        [Display(Prompt="Nombre asignatura", Name ="Nombre")]
        [MinLength(3, ErrorMessage="La longitud mínima de la dirección es 3")]
        public override string Nombre {get; set;}
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}