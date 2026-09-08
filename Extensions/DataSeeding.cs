using EcoScope.Models;
using Microsoft.AspNetCore.Identity;

namespace EcoScope.Extensions
{
    public static class DataSeeding
    {
        public static async Task SeedAdminUser(this WebApplication app) 
        {
            using var scope = app.Services.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var admin = await userManager.FindByEmailAsync("admin@ecoscope.se");

            if(admin != null)
            {
                return;
            }

            admin = new User
            {
                UserName = "admin@ecoscope.se",
                Email = "admin@ecoscope.se",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(admin, "Admin123!");

            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
