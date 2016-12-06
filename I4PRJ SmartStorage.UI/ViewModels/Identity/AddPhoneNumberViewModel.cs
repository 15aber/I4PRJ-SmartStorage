using System.ComponentModel.DataAnnotations;

namespace SmartStorage.UI.ViewModels.Identity
{
  public class AddPhoneNumberViewModel
  {
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string Number { get; set; }
  }
}