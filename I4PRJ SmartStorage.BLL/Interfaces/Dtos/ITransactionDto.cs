using I4PRJ_SmartStorage.DAL.Interfaces.Models;
using System;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Dtos
{
  public interface ITransactionDto
  {
    string ByUser { get; set; }
    IInventory FromInventory { get; set; }
    int? FromInventoryId { get; set; }
    IProduct Product { get; set; }
    int ProductId { get; set; }
    double Quantity { get; set; }
    IInventory ToInventory { get; set; }
    int ToInventoryId { get; set; }
    int TransactionId { get; set; }
    DateTime Updated { get; set; }
  }
}