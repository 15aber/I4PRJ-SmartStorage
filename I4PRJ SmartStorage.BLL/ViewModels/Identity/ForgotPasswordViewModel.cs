using System.ComponentModel.DataAnnotations;

namespace SmartStorage.BLL.ViewModels.Identity
{
  public class ForgotPasswordViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}