using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raspertise.Areas.Identity.Data;
using Raspertise.Models;

[assembly: HostingStartup(typeof(Raspertise.Areas.Identity.IdentityHostingStartup))]

namespace Raspertise.Areas.Identity {

    public class IdentityHostingStartup : IHostingStartup {

        public void Configure(IWebHostBuilder builder) {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RaspertiseIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("RaspertiseIdentityDbContextConnection")));
                
                services.AddIdentity<AppUser, IdentityRole>(opts => {
                        opts.Password.RequiredLength = 6;
                        opts.Password.RequireNonAlphanumeric = false;
                        opts.Password.RequireLowercase = false;
                        opts.Password.RequireUppercase = false;
                        opts.Password.RequireDigit = false;
                        opts.User.RequireUniqueEmail = true;
                    }).AddEntityFrameworkStores<RaspertiseIdentityDbContext>()
//                .AddDefaultUI(UIFramework.Bootstrap4)
                    .AddDefaultTokenProviders();
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                
                services.ConfigureApplicationCookie(opts => {
                    opts.LoginPath = "/Account/Login";
                    opts.LogoutPath = "/Account/Logout";
                });
            });
        }

    }

}