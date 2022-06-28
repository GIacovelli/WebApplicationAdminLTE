using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using WebApplicationAdminLTE.Constants;
using WebApplicationAdminLTE.Models;

namespace WebApplicationAdminLTE.Seeds;

public static class DefaultUsers
{
    
    public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var defaultUser = new ApplicationUser
        {
            UserName = "superadmin@gmail.com",
            Email = "superadmin@gmail.com",
            EmailConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                await userManager.AddToRoleAsync(defaultUser, Roles.Student.ToString());
                await userManager.AddToRoleAsync(defaultUser, Roles.Teacher.ToString());
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
            }
            await roleManager.SeedClaimsForSuperAdmin();
        }
    }
    private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
    {
        var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
        await roleManager.AddPermissionClaim(adminRole, "Products");
    }
    public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
    {
        var allClaims = await roleManager.GetClaimsAsync(role);
        var allPermissions = Permissions.GeneratePermissionsForModule(module);
        foreach (var permission in allPermissions)
        {
            if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
            {
                await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
    }
}