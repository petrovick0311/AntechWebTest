using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AntechLicense.Models;
using Microsoft.AspNetCore.Identity;

namespace AntechLicense
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        private IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(opts => {
                opts.UseSqlServer(Configuration[
                "ConnectionStrings:AntechLicenseDBCnx"]);
                opts.EnableSensitiveDataLogging(true);                                
            });
            services.AddScoped<IStoreRepository, EFStoreRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddServerSideBlazor();

            services.AddDbContext<AppIdentityDbContext>(options => 
                options.UseSqlServer(Configuration[
                    "ConnectionStrings:IdentityConnection"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsProduction())
            {
                app.UseExceptionHandler("/error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }


            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage", "{TipoLicencia}/Page{LicensePage:int}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page", "Page{LicensePage:int}",
                new { Controller = "Home", action = "Index", LicensePage = 1 });

                endpoints.MapControllerRoute("TipoLicencia", "{TipoLicencia}",
                new { Controller = "Home", action = "Index", LicensePage = 1 });

                endpoints.MapControllerRoute("pagination",  "Licencias/Page{LicensePage}",
                new { Controller = "Home", action = "Index", LicensePage = 1 });

                endpoints.MapControllerRoute("Recompensas", "Test/Recompensas",
                new { Controller = "Home", action = "Recompensas" });

                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

                endpoints.MapControllers();
            });

            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
