using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SmartStorage.BLL.Interfaces.Dtos;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.BLL.Dtos
{
  public class TransactionDto : ITransactionDto
  {
    [DisplayName("#")]
    public int TransactionId { get; set; }

    [DisplayName("From")]
    public int? FromInventoryId { get; set; }
    public IInventory FromInventory { get; set; }

    [Required]
    [DisplayName("To")]
    public int ToInventoryId { get; set; }
    public IInventory ToInventory { get; set; }

    [Required]
    [DisplayName("Product")]
    public int ProductId { get; set; }
    public IProduct Product { get; set; }

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