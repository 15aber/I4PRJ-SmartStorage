using System.ComponentModel.DataAnnotations;

namespace SmartStorage.BLL.ViewModels.Identity
{
  public class UserViewModel
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
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [DataType(dataType: DataType.ImageUrl)]
    public string ProfilePicture { get; set; }

    [Display(Name = "Admin")]
    public bool IsAdmin { get; set; }
  }
}