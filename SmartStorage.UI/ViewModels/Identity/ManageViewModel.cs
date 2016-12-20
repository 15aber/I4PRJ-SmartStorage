using System.Diagnostics.CodeAnalysis;

namespace SmartStorage.UI.ViewModels.Identity
{
  [ExcludeFromCodeCoverage]
  public class ManageViewModel
  {
    public bool HasPassword { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
  }
}