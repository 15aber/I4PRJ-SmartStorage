using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartStorage.BLL.Dtos
{
  public class CategoryDto
  {
    [DisplayName("#")]
    public int CategoryId { get; set; }

    [Required]
    [DisplayName("Category")]
    public string Name { get; set; }

    [DisplayName("Updated")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}")]
    [Editable(false)]
    public DateTime Updated { get; set; }

    [DisplayName("By")]
    [Editable(false)]
    public string ByUser { get; set; }

    [DisplayName("Archived")]
    [Editable(false)]
    public bool IsDeleted { get; set; }
  }
}