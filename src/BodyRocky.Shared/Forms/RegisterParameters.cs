using System.ComponentModel.DataAnnotations;

namespace BodyRocky.Shared.Forms;

public class RegisterParameters
{
    [Required]
    [Display(Name = "Prénom")]
    [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Nom")]
    [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Adresse e-mail")]
    [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide.")]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Mot de passe")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Confirmation du mot de passe")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Le mot de passe et la confirmation du mot de passe ne correspondent pas.")]
    public string ConfirmPassword { get; set; } = string.Empty;
    
    // [Required]
    // [Display(Name = "Date de naissance")]
    // [DataType(DataType.Date)]
    // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    // [Range(typeof(DateTime), "01/01/1900", "01/01/2015", ErrorMessage = "La date de naissance doit être comprise entre le 01/01/1900 et le 01/01/2015")]
    // public DateTime BirthDate { get; set; }
}