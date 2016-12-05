using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.DAL.Models
{
  public class StockModel : IStockModel
  {
    [Key]
    [Column(Order = 0)]
    [Required]
    [DisplayName("InventoryModel")]
    public int InventoryId { get; set; }

    public IInventoryModel Inventory { get; set; }

    [Key]
    [Column(Order = 1)]
    [Required]
    [DisplayName("ProductModel")]
    public int ProductId { get; set; }

    public IProductModel Product { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    [Range(Double.MinValue, Double.MaxValue)]
    public double Quantity { get; set; }
  }
}