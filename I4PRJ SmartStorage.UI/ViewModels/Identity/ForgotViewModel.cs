using System.ComponentModel.DataAnnotations;

namespace SmartStorage.UI.ViewModels.Identity
{
  public class ForgotViewModel
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}