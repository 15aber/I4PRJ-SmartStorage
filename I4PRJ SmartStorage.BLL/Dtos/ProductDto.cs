using SmartStorage.DAL.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartStorage.BLL.Dtos
{
  public class ProductDto
  {
    [DisplayName("#")]
    public int ProductId { get; set; }

    [Required]
    [StringLength(255)]
    [DisplayName("Product")]
    public string Name { get; set; }

    [Required]
    [DisplayName("Purchase Price")]
    [DataType(DataType.Currency)]
    [Range(0, Double.MaxValue)]
    public double PurchasePrice { get; set; }

    [Required]
    [DisplayName("Category")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    [Required]
    [DisplayName("Supplier")]
    public int SupplierId { get; set; }

    public Supplier Supplier { get; set; }

    [Required]
    [DisplayName("Wholesaler")]
    public int WholesalerId { get; set; }

    public Wholesaler Wholesaler { get; set; }

    [DisplayName("Updated")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}")]
    [Editable(false)]
    public DateTime Updated { get; set; }

    [DisplayName("By")]
    [Editable(false)]
    public string ByUser { get; set; }

    [DisplayName("Archived")]
    [Editable(false)]
    public bool IsDeleted { get; set; }
  }
}