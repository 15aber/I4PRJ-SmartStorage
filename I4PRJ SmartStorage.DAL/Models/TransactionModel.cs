using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.DAL.Models
{
  public class TransactionModel : ITransactionModel
  {
    [Key]
    [DisplayName("#")]
    public int TransactionId { get; set; }

    [ForeignKey("FromInventory")]
    [DisplayName("From")]
    public int? FromInventoryId { get; set; }

    public IInventoryModel FromInventory { get; set; }

    [Required]
    [ForeignKey("ToInventory")]
    [DisplayName("To")]
    public int ToInventoryId { get; set; }

    public IInventoryModel ToInventory { get; set; }

    [Required]
    [ForeignKey("ProductModel")]
    [DisplayName("ProductModel")]
    public int ProductId { get; set; }

    public IProductModel Product { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    [Range(Double.MinValue, Double.MaxValue)]
    public double Quantity { get; set; }

    [DisplayName("Updated")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}")]
    [Editable(false)]
    public DateTime Updated { get; set; }

    [DisplayName("By")]
    [Editable(false)]
    public string ByUser { get; set; }
  }
}