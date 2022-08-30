using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCore.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public HomeController(ILogger<HomeController> logger, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
    {
      _logger = logger;
      _userManager = userManager;
      _roleManager = roleManager;
    }

    public async Task<IActionResult> IndexAsync()
    {
      var user = await _userManager.FindByEmailAsync("patriciomiguel_12@hotmail.com");

      if (user == null)
      {
        await _roleManager.CreateAsync(new IdentityRole("SysAdmin"));
        await _roleManager.CreateAsync(new IdentityRole("Admin"));

        var newUser = new Usuario()
        {
          Nombres = "Patricio Miguel",
          ApellidoP = "Osorio",
          ApellidoM = "Osorio",
          UserName = "patriciomiguel_12@hotmail.com",
          Email = "patriciomiguel_12@hotmail.com",
          EmailConfirmed = true
        };
        await _userManager.CreateAsync(newUser, "Pato12345.");
        await _userManager.AddToRoleAsync(newUser, "SysAdmin");
      }

      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
