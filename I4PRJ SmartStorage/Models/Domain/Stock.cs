using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I4PRJ_SmartStorage.Models.Domain
{
  public class Stock
  {
    [Key]
    [Column(Order = 0)]
    [Required]
    [DisplayName("Inventory")]
    public int InventoryId { get; set; }

    public Inventory Inventory { get; set; }

    [Key]
    [Column(Order = 1)]
    [Required]
    [DisplayName("Product")]
    public int ProductId { get; set; }

    public Product Product { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    [Range(Double.MinValue, Double.MaxValue)]
    public double Quantity { get; set; }
  }
}