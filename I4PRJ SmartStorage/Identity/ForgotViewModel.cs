using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.UI.Identity
{
  public class ForgotViewModel
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}