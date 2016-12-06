using I4PRJ_SmartStorage.BLL.Interfaces.Dtos;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.BLL.Dtos
{
  public class StockDto : IStockDto
  {
    [Required]
    [DisplayName("Inventory")]
    public int InventoryId { get; set; }

    public IInventory Inventory { get; set; }

    [Required]
    [DisplayName("Product")]
    public int ProductId { get; set; }

    public IProduct Product { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:G}")]
    [Range(Double.MinValue, Double.MaxValue)]
    public double Quantity { get; set; }
  }
}