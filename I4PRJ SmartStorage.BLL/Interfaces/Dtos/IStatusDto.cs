using System;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.BLL.Interfaces.Dtos
{
  public interface IStatusDto
  {
    string ByUser { get; set; }
    double CurQuantity { get; set; }
    double Difference { get; set; }
    double ExpQuantity { get; set; }
    IInventory Inventory { get; set; }
    int InventoryId { get; set; }
    bool IsStarted { get; set; }
    IProduct Product { get; set; }
    int ProductId { get; set; }
    int StatusId { get; set; }
    DateTime Updated { get; set; }
  }
}