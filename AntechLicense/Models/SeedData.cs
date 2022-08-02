using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AntechLicense.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            DataContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
            
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Licencias.Any())
            {
                context.Licencias.AddRange(
                new Licencia
                {
                    //LicenciaID = 1,
                    NumeroLicencia = "1",
                    eMail = "pedro.pedrinsky1@gmail.com",
                    NombrePropietario = "Pedro Ruiz",
                    NombreSucursal = "Atoyac",
                    MacAddress = "192.192.192.2",
                    Ubicacion = "12.12",
                    TipoLicencia = "Cadena",
                    Precio = 500
                },
                new Licencia
                {
                    //LicenciaID = 2,
                    NumeroLicencia = "2",
                    eMail = "pedro.pedrinsky1@gmail.com",
                    NombrePropietario = "Jose Rubio",
                    NombreSucursal = "Matamoros",
                    MacAddress = "192.192.168.2",
                    Ubicacion = "12.12.0.0",
                    TipoLicencia = "Cadena",
                    Precio = 5005
                },
                new Licencia
                {
                    //LicenciaID = 3,
                    NumeroLicencia = "3",
                    eMail = "pedro.pedrinsky1@gmail.com",
                    NombrePropietario = "Juan Tristan",
                    NombreSucursal = "Santo Domingo",
                    MacAddress = "192.192.182.2",
                    Ubicacion = "12.12.12.36",
                    TipoLicencia = "Sucursal",
                    Precio = 850
                }
                );
                context.SaveChanges();
            }
        }
    }
}
