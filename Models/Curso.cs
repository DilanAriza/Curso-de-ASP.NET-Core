using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Curso_de_ASP.NET_Core.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Required(ErrorMessage="El nombre del curso es un campo requerido")]
        [StringLength(3)]
        [Display(Prompt="Nombre del curso", Name ="Nombre")]
        public override string Nombre {set;get;}
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }

        [Display(Prompt="Dirección correspondencia", Name ="Dirección")]
        [Required(ErrorMessage="Se requiere una dirección")]
        [MinLength(10, ErrorMessage="La longitud mínima de la dirección es 10")]
        public string Dirección { get; set; }
        public string EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
    }
}