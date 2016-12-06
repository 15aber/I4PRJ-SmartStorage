using System;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Interfaces.Models
{
  public interface IStatus
  {
    string ByUser { get; set; }
    double CurQuantity { get; set; }
    double Difference { get; set; }
    double ExpQuantity { get; set; }
    Inventory Inventory { get; set; }
    int InventoryId { get; set; }
    bool IsStarted { get; set; }
    Product Product { get; set; }
    int ProductId { get; set; }
    int StatusId { get; set; }
    DateTime Updated { get; set; }
  }
}