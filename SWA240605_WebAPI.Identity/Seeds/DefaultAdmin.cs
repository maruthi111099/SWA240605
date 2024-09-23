using Microsoft.AspNetCore.Identity;
using SWA240605_WebAPI.Application.Enums;
using SWA240605_WebAPI.Identity.Models;

namespace SWA240605_WebAPI.Identity.Seeds
{
    public static class DefaultAdmin
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "iyyappan",
                Email = "iyyappanr@gmail.com",
                Name = "Iyyappan R",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    var result = await userManager.CreateAsync(defaultUser, "1234__DVs1@");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(defaultUser, UserRoles.Admin.ToString());
                        await userManager.AddToRoleAsync(defaultUser, UserRoles.SuperAdmin.ToString());
                        await userManager.AddToRoleAsync(defaultUser, UserRoles.Applicant.ToString());
                    }
                }
                else
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    await userManager.ResetPasswordAsync(user, token, "admin@1234_DVs1@");
                }
            }
        }
    }

}
