using System.ComponentModel.DataAnnotations;

namespace SmartStorage.BLL.ViewModels.Identity
{
  public class ForgotViewModel
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}