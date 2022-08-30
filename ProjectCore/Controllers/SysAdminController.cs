using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectCore.Models;
using System.Linq;

namespace ProjectCore.Controllers
{
  [Authorize(Roles = "SysAdmin, Admin")]
  public class SysAdminController : Controller
  {
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<Usuario> _userManager;

    public SysAdminController(RoleManager<IdentityRole> roleManager, UserManager<Usuario> userManager)
    {
      _roleManager = roleManager;
      _userManager = userManager;
    }

    public IActionResult Index()
    {
      var users = _userManager.Users.ToList();
      return View(users);
    }
  }
}
