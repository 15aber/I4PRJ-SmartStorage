using I4PRJ_SmartStorage.BLL.Interfaces.Dtos;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.BLL.Dtos
{
  public class TransactionDto : ITransactionDto
  {
    [DisplayName("#")]
    public int TransactionId { get; set; }

    [DisplayName("From")]
    public int? FromInventoryId { get; set; }
    public IInventoryModel FromInventory { get; set; }

    [Required]
    [DisplayName("To")]
    public int ToInventoryId { get; set; }
    public IInventoryModel ToInventory { get; set; }

    [Required]
    [DisplayName("Product")]
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