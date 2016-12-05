using System;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Models
{
  public interface ITransactionModel
  {
    string ByUser { get; set; }
    IInventoryModel FromInventory { get; set; }
    int? FromInventoryId { get; set; }
    IProductModel Product { get; set; }
    int ProductId { get; set; }
    double Quantity { get; set; }
    IInventoryModel ToInventory { get; set; }
    int ToInventoryId { get; set; }
    int TransactionId { get; set; }
    DateTime Updated { get; set; }
  }
}