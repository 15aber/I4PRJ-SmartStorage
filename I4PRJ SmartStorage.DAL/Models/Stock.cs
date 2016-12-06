using I4PRJ_SmartStorage.DAL.Interfaces.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I4PRJ_SmartStorage.DAL.Models
{
  public class Stock : IStock
  {
    [Key]
    [Column(Order = 0)]
    [Required]
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    [Key]
    [Column(Order = 1)]
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public double Quantity { get; set; }
  }
}