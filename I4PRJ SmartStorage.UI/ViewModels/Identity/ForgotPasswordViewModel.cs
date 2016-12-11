using System.ComponentModel.DataAnnotations;

namespace SmartStorage.UI.ViewModels.Identity
{
  public class ForgotPasswordViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}