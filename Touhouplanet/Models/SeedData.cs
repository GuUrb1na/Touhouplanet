using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Touhouplanet.Data;
using Touhouplanet.Models;

namespace MvcTouhou.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTouhouContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTouhouContext>>()))
            {
                // Look for any Touhous.
                if (context.Touhou.Any())
                {
                    return;   // DB has been seeded
                }

                context.Touhou.AddRange(
                    new Touhou
                    {
                        Nombre = "Reimu Hakurei",
                        Especie = "Humana",
                        Habilidad = "Levitar",
                        Ocupacion = "Miko",
                        Ubicacion = "Hakurei Shrine",
                        Imagen = ""
                    },

                    new Touhou
                    {
                        Nombre = "Marisa Kirisame",
                        Especie = "Humana",
                        Habilidad = "Uso de magia",
                        Ocupacion = "Maga",
                        Ubicacion = "The Kirisame household",
                        Imagen = ""
                    }
                );
                context.SaveChanges();
            }
        }
    }
}