using System.ComponentModel.DataAnnotations;

namespace BodyRocky.Shared.Forms;

public class LoginParameters
{
    [Required]
    [Display(Name = "Adresse e-mail")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Mot de passe")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    
    public bool RememberMe { get; set; }
}