using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Models
{
  public class Usuario : IdentityUser
  {
    [PersonalData]
    [Display(Name = "Nombres")]
    public string Nombres { get; set; }

    [PersonalData]
    [Display(Name = "Apellido paterno")]
    public string ApellidoP { get; set; }

    [PersonalData]
    [Display(Name = "Apellido materno")]
    public string ApellidoM { get; set; }
  }
}
