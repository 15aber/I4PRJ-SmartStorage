using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartStorage.BLL.Dtos
{
  public class WholesalerDto
  {
    [DisplayName("#")]
    public int WholesalerId { get; set; }

    [Required]
    [DisplayName("Wholesaler")]
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