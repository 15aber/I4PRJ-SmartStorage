using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SmartStorage.BLL.Interfaces.Dtos;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.BLL.Dtos
{
  public class ProductDto : IProductDto
  {
    [DisplayName("#")]
    public int ProductId { get; set; }

    [Required]
    [StringLength(255)]
    [DisplayName("ProductModel")]
    public string Name { get; set; }

    [Required]
    [DisplayName("Purchase Price")]
    [DataType(DataType.Currency)]
    [Range(0, Double.MaxValue)]
    public double PurchasePrice { get; set; }

    [Required]
    [DisplayName("Category")]
    public int CategoryId { get; set; }

    public ICategory Category { get; set; }

    [Required]
    [DisplayName("Supplier")]
    public int SupplierId { get; set; }

    public ISupplier Supplier { get; set; }

    [Required]
    [DisplayName("Wholesaler")]
    public int WholesalerId { get; set; }

    public IWholesaler Wholesaler { get; set; }

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