using System.ComponentModel.DataAnnotations;

namespace BodyRocky.Shared.Forms;

public class CheckoutParameters
{
    [Required]
    [Display(Name = "Prénom")]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Nom")]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [Display(Name = "Téléphone")]
    public string PhoneNumber { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string EmailAddress { get; set; } = string.Empty;
}