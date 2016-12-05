using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.Identity
{
  public class RegisterViewModel
  {
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone")]
    public string PhoneNumber { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string FullName { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    [DataType(dataType: DataType.ImageUrl)]
    public string ProfilePicture { get; set; }

    [Display(Name = "Admin")]
    public bool IsAdmin { get; set; }
  }
}