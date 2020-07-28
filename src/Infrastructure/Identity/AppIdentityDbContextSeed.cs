using Microsoft.AspNetCore.Identity;
using Microsoft.eShopWeb.ApplicationCore.Constants;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS));

            var defaultUser = new ApplicationUser { UserName = "sistemaCompras@pruebas.com", Email = "sistemaCompras@pruebas.com" };
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);

            string adminUserName = "sistemaCompras@pruebas.com";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, AuthorizationConstants.DEFAULT_PASSWORD);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS);
        }
    }
}
