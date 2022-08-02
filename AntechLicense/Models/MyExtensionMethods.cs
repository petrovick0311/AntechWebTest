using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntechLicense.Models
{
    public static class MyExtensionMethods
    {
        public static async Task MigrateDataBaseAsync(this IHost webHost)
        {
            using (var Scope = webHost.Services.CreateScope())
            {
                var services = Scope.ServiceProvider;
                using (var context = services.GetRequiredService<DataContext>())
                {
                    try
                    {
                        await context.Database.MigrateAsync();                        
                        // Put any complex database seeding here
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while migrating the database");

                        throw;
                    }
                }
            }
        }
    }
}
