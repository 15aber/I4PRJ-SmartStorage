using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SmartStorage.UI.ViewModels.Identity
{
  [ExcludeFromCodeCoverage]
  public class AddPhoneNumberViewModel
  {
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string Number { get; set; }
  }
}