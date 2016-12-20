using SmartStorage.DAL.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartStorage.BLL.Dtos
{
  public class StockDto
  {
    [Required]
    [DisplayName("Inventory")]
    public int InventoryId { get; set; }

    public Inventory Inventory { get; set; }

    [Required]
    [DisplayName("Product")]
    public int ProductId { get; set; }

    public Product Product { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:G}")]
    [Range(Double.MinValue, Double.MaxValue)]
    public double Quantity { get; set; }
  }
}