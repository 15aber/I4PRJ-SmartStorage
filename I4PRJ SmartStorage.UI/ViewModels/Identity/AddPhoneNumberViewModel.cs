using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.ViewModels.Identity
{
  public class AddPhoneNumberViewModel
  {
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string Number { get; set; }
  }
}