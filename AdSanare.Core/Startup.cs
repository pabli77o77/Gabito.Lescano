using AdSanare.Context;
using AdSanare.Entities;
using AdSanare.Logic;
using AdSanare.Logic.Interfaces;
using AdSanare.Repository;
using AdSanare.Repository.Interfaces;
using AdSanare.UOW;
using AdSanare.UOW.Interfaces;
using AdSanare.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdSanare.Core
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

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc(
                options =>
                {
                    options.CacheProfiles.Add("DefaultNoCacheProfile", new CacheProfile
                    {
                        NoStore = true,
                        Location = ResponseCacheLocation.None
                    });
                    options.Filters.Add(new ResponseCacheAttribute
                    {
                        CacheProfileName = "DefaultNoCacheProfile"
                    });
                })
                .AddFluentValidation(v =>{
                v.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            }) ;

            #region Repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IExamenComplementarioRepository, ExamenComplementarioRepository>();
            services.AddTransient<IServicioRepository, ServicioRepository>();
            services.AddTransient<ICamaRepository, CamaRepository>();
            services.AddTransient<IIngresoRepository, IngresoRepository>();
            services.AddTransient<IEvolucionRepository, EvolucionRepository>();
            services.AddTransient<IExamenFisicoRepository, ExamenFisicoRepository>();
            #endregion
            #region Unidad de Trabajo
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
            #region Logica de Negocio
            services.AddTransient<IPacienteLogic, PacienteLogic>();
            services.AddTransient<IExamenComplementarioLogic, ExamenComplementarioLogic>();
            services.AddTransient<IServicioLogic, ServicioLogic>();
            services.AddTransient<ICamaLogic, CamaLogic>();
            services.AddTransient<IIngresoLogic, IngresoLogic>();
            services.AddTransient<IEvolucionLogic, EvolucionLogic>();
            #endregion
            #region Validador
            services.AddTransient<IValidator<Paciente>, PacienteValidator>();
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);
            #endregion
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
