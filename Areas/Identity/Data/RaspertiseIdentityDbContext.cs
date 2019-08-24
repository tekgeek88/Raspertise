using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raspertise.Models;

namespace Raspertise.Areas.Identity.Data {

    public class RaspertiseIdentityDbContext : IdentityDbContext<AppUser> {

        public RaspertiseIdentityDbContext(DbContextOptions<RaspertiseIdentityDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        
        
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
            IConfiguration configuration) {
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string username = configuration["Data:AdminUser:UserName"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];

            if (await userManager.FindByNameAsync(username) == null) {
                if (await roleManager.FindByNameAsync(role) == null) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                AppUser user = new AppUser {
                    UserName = username,
                    Email = email
                };
                IdentityResult result = await userManager
                    .CreateAsync(user, password);

                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
        
        
        public static async Task CreateRoles(IServiceProvider serviceProvider) {
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = {"Sponsor", "Advertiser"};
            IdentityResult roleResult;

            foreach (var roleName in roleNames) {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists) {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

    }

}