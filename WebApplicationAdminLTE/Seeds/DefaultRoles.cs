using Microsoft.AspNetCore.Identity;
using WebApplicationAdminLTE.Constants;
using WebApplicationAdminLTE.Models;

namespace WebApplicationAdminLTE.Seeds;

public static class DefaultRoles
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Teacher.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Student.ToString()));
    }
}