using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.DAL.Models
{
  public class StatusModel : IStatusModel
  {
    [Key]
    [DisplayName("#")]
    public int StatusId { get; set; }

    [Required]
    [ForeignKey("InventoryModel")]
    [DisplayName("InventoryModel")]
    public int InventoryId { get; set; }
    public IInventoryModel Inventory { get; set; }

    [Required]
    [ForeignKey("ProductModel")]
    [DisplayName("ProductModel")]
    public int ProductId { get; set; }
    public IProductModel Product { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public double ExpQuantity { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public double CurQuantity { get; set; }

    [Range(Double.MinValue, Double.MaxValue)]
    [Editable(false)]
    public double Difference { get; set; }

    [DisplayName("Updated")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}")]
    [Editable(false)]
    public DateTime Updated { get; set; }

    [DisplayName("By")]
    [Editable(false)]
    public string ByUser { get; set; }

    [Editable(false)]
    public bool IsStarted { get; set; }
  }
}