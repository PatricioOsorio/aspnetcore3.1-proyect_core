using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCore.Models
{
  public class DbInitializer
  {
    public static async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
      var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
      var userManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();

      var roles = new List<string>() { "Admin", "SysAdmin" };

      foreach (var role in roles)
      {
        if (!await roleManager.RoleExistsAsync(role))
        {
          await roleManager.CreateAsync(new IdentityRole(role));
        }
      }

      Usuario user = await userManager.FindByEmailAsync("PatricioMiguel_12@hotmail.com");

      await userManager.AddToRoleAsync(user, "SysAdmin");
    }
  }
}
