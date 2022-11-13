using System.ComponentModel.DataAnnotations;

namespace BodyRocky.Front.WebApp.Shared.FormModels;

public class LoginModel
{
    [Required]
    [Display(Name = "Adresse e-mail")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Mot de passe")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}