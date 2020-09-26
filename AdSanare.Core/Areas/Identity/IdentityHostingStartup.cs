using AdSanare.Entities;
using AdSanare.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

[assembly: HostingStartup(typeof(AdSanare.Core.Areas.Identity.IdentityHostingStartup))]
namespace AdSanare.Core.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AdSanareUsuariosDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AdSanareUsuarios")));

                services.AddIdentity<Usuario, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<AdSanareUsuariosDbContext>();
            });
        }
    }
}