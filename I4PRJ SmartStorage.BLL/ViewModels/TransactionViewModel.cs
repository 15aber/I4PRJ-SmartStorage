using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.ViewModels
{
  public class TransactionViewModel
  {
    public List<IInventoryModel> FromInventory { get; set; }

    public List<IInventoryModel> ToInventory { get; set; }

    public List<IProductModel> Products { get; set; }

    public List<ITransactionModel> Transactions { get; set; }

    public ITransactionModel Transaction { get; set; }

    [DisplayName("Restock")]
    public bool IsChecked { get; set; }

    [Required]
    [DisplayName("From")]
    public int FromInventoryId { get; set; }

    [Required]
    [DisplayName("To")]
    public int ToInventoryId { get; set; }

    [Required]
    [DisplayName("ProductModel")]
    public int ProductId { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    [Range(Double.MinValue, Double.MaxValue)]
    public double Quantity { get; set; }
  }
}