using System;
using data.context;
using data.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(PropertyManagement.Areas.Identity.IdentityHostingStartup))]
namespace PropertyManagement.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<FSPropertyManagementIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FSPropertyManagementContext")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<FSPropertyManagementIdentityContext>();

            });
        }
    }
}