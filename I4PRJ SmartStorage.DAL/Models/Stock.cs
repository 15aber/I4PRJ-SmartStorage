using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.DAL.Models
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