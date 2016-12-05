using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.DAL.Models
{
  public class WholesalerModel : IWholesalerModel
  {
    [Key]
    [DisplayName("#")]
    public int WholesalerId { get; set; }

    [Required]
    [DisplayName("WholesalerModel")]
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