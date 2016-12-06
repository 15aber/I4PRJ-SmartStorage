using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.DAL.Models
{
  public class Status : IStatus
  {
    [Key]
    public int StatusId { get; set; }

    [Required]
    [ForeignKey("Inventory")]
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public double ExpQuantity { get; set; }

    [Required]
    public double CurQuantity { get; set; }

    public double Difference { get; set; }

    [Required]
    public DateTime Updated { get; set; }

    [StringLength(256)]
    public string ByUser { get; set; }

    public bool IsStarted { get; set; }
  }
}