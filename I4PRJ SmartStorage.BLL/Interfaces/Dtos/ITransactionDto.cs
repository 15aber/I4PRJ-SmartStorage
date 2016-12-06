using System;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.BLL.Interfaces.Dtos
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