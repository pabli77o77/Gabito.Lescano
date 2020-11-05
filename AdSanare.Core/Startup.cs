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
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericUserRepository<>));
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IExamenComplementarioRepository, ExamenComplementarioRepository>();
            services.AddTransient<IServicioRepository, ServicioRepository>();
            services.AddTransient<ICamaRepository, CamaRepository>();
            services.AddTransient<IIngresoRepository, IngresoRepository>();
            services.AddTransient<IEvolucionRepository, EvolucionRepository>();
            services.AddTransient<IExamenFisicoRepository, ExamenFisicoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IAuditoriaRepository, AuditoriaRepository>();
            services.AddTransient<IDomicilioRepository, DomicilioRepository>();
            services.AddTransient<IObraSocialRepository, ObraSocialRepository>();
            #endregion
            #region Unidad de Trabajo
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserUnitOfWork, UsuarioUnitOfWork>();
            #endregion
            #region Logica de Negocio
            services.AddTransient<IPacienteLogic, PacienteLogic>();
            services.AddTransient<IExamenComplementarioLogic, ExamenComplementarioLogic>();
            services.AddTransient<IServicioLogic, ServicioLogic>();
            services.AddTransient<ICamaLogic, CamaLogic>();
            services.AddTransient<IIngresoLogic, IngresoLogic>();
            services.AddTransient<IEvolucionLogic, EvolucionLogic>();
            services.AddTransient<IUsuarioLogic, UsuarioLogic>();
            services.AddTransient<IAuditoriaLogic, AuditoriaLogic>();
            services.AddTransient<IDomicilioLogic, DomicilioLogic>();
            services.AddTransient<IObraSocialLogic, ObraSocialLogic>();
            #endregion
            #region Validador
            services.AddTransient<IValidator<Paciente>, PacienteValidator>();
            services.AddTransient<IValidator<Cama>, CamaValidator>();
            services.AddTransient<IValidator<Evolucion>, EvolucionValidator>();
            services.AddTransient<IValidator<ExamenComplementario>, ExamenComplementarioValidator>();
            services.AddTransient<IValidator<ExamenFisico>, ExamenFisicoValidator>();
            services.AddTransient<IValidator<Ingreso>, IngresoValidator>();
            services.AddTransient<IValidator<Servicio>, ServicioValidator>();
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
            Rotativa.AspNetCore.RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env, "lib\\Rotativa\\Windows\\");
        }
    }
}
