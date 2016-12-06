using I4PRJ_SmartStorage.DAL.Interfaces.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I4PRJ_SmartStorage.DAL.Models
{
  public class Product : IProduct
  {
    [Key]
    public int ProductId { get; set; }

    [Required]
    [StringLength(256)]
    public string Name { get; set; }

    public double PurchasePrice { get; set; }

    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [ForeignKey("Supplier")]
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    [ForeignKey("Wholesaler")]
    public int WholesalerId { get; set; }
    public Wholesaler Wholesaler { get; set; }

    public DateTime? Updated { get; set; }

    [StringLength(256)]
    public string ByUser { get; set; }

    public bool IsDeleted { get; set; }
  }
}