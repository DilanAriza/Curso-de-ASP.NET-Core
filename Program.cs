using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso_de_ASP.NET_Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Curso_de_ASP.NET_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creamos el host de ejecución del programa
            var host = CreateHostBuilder(args).Build();

            // Creamos un scope que se elimina cuando se termine de usar dentro de los corchetes
            using(var scope = host.Services.CreateScope())
            {
                // llamamos a todos los servicios y los guardamos en la variable services
                var services = scope.ServiceProvider;
                
                // Manejo de error por si algo xd
                try
                {
                    // Llamamos al contexto de los datos y lo guardamos en una variable context
                    var context = services.GetRequiredService<EscuelaContext>();
                    // Nos aseguramos que los datos se han creado con la funcion EnsureCreated(); 
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    // llamamos a un servicio de log y lo guardamos en la variable de logger
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    // Exponemos el error como un LogError por consola
                    logger.LogError(ex, "An error ocurred creating the DB");
                }
            }

            // Finalmente corremos el host
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
