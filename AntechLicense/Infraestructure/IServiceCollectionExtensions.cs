using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AntechLicense.Models;
using AntechLicense.GenericRepositoryP;
using AntechLicense.NonGenericRepositoryP;
using AntechLicense.UnitOfWork;
using AntechLicense.DBFactory;



namespace AntechLicense.Infraestructure
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                                    {
                                        options.UseSqlServer(
                                                                configuration["ConnectionStrings:AntechLicenseDBCnx"]
                                                            );
                                        options.EnableSensitiveDataLogging(true);                                       
                                    }
                                );
            //services.AddScoped<IStoreRepository, EFStoreRepository>();
            //services.AddScoped(typeof(IDbFactory<>), typeof(DbFactory<>));
            //services.AddScoped<IDbFactory, DbFactory>();
            //services.AddScoped(typeof(IDbFactory<DataContext>), typeof(DbFactory));
            //services.AddScoped<Func<DataContext>>((provider) => () => provider.GetService<DataContext>());

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IGenericRepositoryP<>), typeof(GenericRepositoryP<>));
            //services.AddScoped(typeof(ICocktailRepositoryP<>), typeof(CocktailRepositoryP<>));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {            
            ///*servic*/es.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
