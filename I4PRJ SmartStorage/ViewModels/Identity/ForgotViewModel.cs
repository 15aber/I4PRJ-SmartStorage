using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.ViewModels.Identity
{
  public class ForgotViewModel
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}