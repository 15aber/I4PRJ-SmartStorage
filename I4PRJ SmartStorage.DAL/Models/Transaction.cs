using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.DAL.Models
{
  public class Transaction : ITransaction
  {
    [Key]
    public int TransactionId { get; set; }

    [ForeignKey("FromInventory")]
    public int? FromInventoryId { get; set; }
    public Inventory FromInventory { get; set; }

    [Required]
    [ForeignKey("ToInventory")]
    public int ToInventoryId { get; set; }
    public Inventory ToInventory { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    public double Quantity { get; set; }

    public DateTime? Updated { get; set; }

    [StringLength(256)]
    public string ByUser { get; set; }
  }
}