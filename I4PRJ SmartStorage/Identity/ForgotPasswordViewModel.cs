using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.Identity
{
  public class ForgotPasswordViewModel
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}