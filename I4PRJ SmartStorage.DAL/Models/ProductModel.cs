using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.DAL.Models
{
  public class ProductModel : IProductModel
  {
    [Key]
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
    [ForeignKey("CategoryModel")]
    [DisplayName("CategoryModel")]
    public int CategoryId { get; set; }

    public ICategoryModel Category { get; set; }

    [Required]
    [ForeignKey("SupplierModel")]
    [DisplayName("SupplierModel")]
    public int SupplierId { get; set; }

    public ISupplierModel Supplier { get; set; }

    [Required]
    [ForeignKey("WholesalerModel")]
    [DisplayName("WholesalerModel")]
    public int WholesalerId { get; set; }

    public IWholesalerModel Wholesaler { get; set; }

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