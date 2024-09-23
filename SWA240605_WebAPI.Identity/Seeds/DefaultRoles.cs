using Microsoft.AspNetCore.Identity;
using SWA240605_WebAPI.Application.Enums;
using SWA240605_WebAPI.Identity.Models;

namespace SWA240605_WebAPI.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed Roles
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Applicant.ToString()));
        }
    }
}
