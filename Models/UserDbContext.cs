using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class UserDbContext : IdentityDbContext<AppUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) {}

        public async Task CreateAdminAndRoles(IServiceProvider provider,
            IConfiguration configuration)
        {
            UserManager<AppUser> userManager = provider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            string userRole = configuration["UserRole:User"];
            string adminRole = configuration["UserRole:Admin"];

            if (await roleManager.FindByNameAsync(userRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(userRole));
            }
            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            string login = configuration["Administrator:Login"];
            string password = configuration["Administrator:Password"];

            if (await userManager.FindByEmailAsync(login) == null)
            {
                AppUser user = new AppUser
                {
                    Email = login
                };

                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, userRole);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }
        }

    }
}
