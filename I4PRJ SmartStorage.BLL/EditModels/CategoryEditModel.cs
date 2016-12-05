using I4PRJ_SmartStorage.BLL.Interfaces.EditModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.BLL.EditModels
{
  public class CategoryEditModel : ICategoryEditModel
  {
    [Required]
    [DisplayName("Category")]
    public string Name { get; set; }
  }
}