using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Curso_de_ASP.NET_Core.Models
{
    public class EscuelaContext: DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }
        
        public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogotá";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Avenida Siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            // Cargar Curso de la escuela
            var cursos = CargarCursos(escuela);

            // X cada curso carga asignaturas
            var asignaturas = CargarAsignaturas(cursos);

            // X cada curso carga alumnos
            var alumnos = CargarAlumnos(cursos);

            // Carga de evaluaciones

            // Guardando datos
            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());
        }


        /*
         * Metodos para carga de cursos y asignatura
        */        
        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var listaCompleta = new List<Asignatura> ();
            foreach (var curso in cursos)
            {
                var tmpList = new List<Asignatura>{
                    new Asignatura { Nombre = "Matemáticas", CursoId = curso.Id },
                    new Asignatura { Nombre = "Educación Física", CursoId = curso.Id },
                    new Asignatura { Nombre = "Castellano", CursoId = curso.Id },
                    new Asignatura { Nombre = "Ciencias Naturales", CursoId = curso.Id },
                    new Asignatura { Nombre = "Programacion", CursoId = curso.Id, }
                };

                listaCompleta.AddRange(tmpList);
            }

            return listaCompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                new Curso(){
                    EscuelaId=escuela.Id,
                    Nombre="101",
                    Jornada= TiposJornada.Mañana
                },
                new Curso(){
                    EscuelaId=escuela.Id,
                    Nombre="201",
                    Jornada= TiposJornada.Mañana
                },
                new Curso(){
                    EscuelaId=escuela.Id,
                    Nombre="301",
                    Jornada= TiposJornada.Mañana
                },
                new Curso(){
                    EscuelaId=escuela.Id,
                    Nombre="401",
                    Jornada= TiposJornada.Tarde
                },
                new Curso(){
                    EscuelaId=escuela.Id,
                    Nombre="501",
                    Jornada= TiposJornada.Tarde
                }
            };
        }

        private List<Alumno> CargarAlumnos(List<Curso> cursos){

            var listaAlumnos = new List<Alumno>();
            Random rnd = new Random();

            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20); 
                var tmpList = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmpList);   
            }

            return listaAlumnos;
        }

        private List<Alumno> GenerarAlumnosAlAzar(
            Curso curso,
            int cantidad
        )
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno {
                                    CursoId = curso.Id,
                                    Nombre = $"{n1} {n2} {a1}",
                                };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }
    }
}