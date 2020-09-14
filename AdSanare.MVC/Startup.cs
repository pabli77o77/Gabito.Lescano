using AdSanare.Context;
using AdSanare.Logic;
using AdSanare.Logic.Interfaces;
using AdSanare.Repository;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW;
using AdSanare.UOW.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdSanare.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AdSanareDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("AdSanare"))
                );
            #region Repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            #endregion
            #region Unidad de Trabajo
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
            #region Logica de Negocio
            services.AddTransient<IPersonaLogic, PersonaLogic>();
            #endregion
            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStatusCodePages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
