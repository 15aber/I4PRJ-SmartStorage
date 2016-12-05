using I4PRJ_SmartStorage.DAL.Interfaces.Models;
using System;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Dtos
{
  public interface IStatusDto
  {
    string ByUser { get; set; }
    double CurQuantity { get; set; }
    double Difference { get; set; }
    double ExpQuantity { get; set; }
    IInventoryModel Inventory { get; set; }
    int InventoryId { get; set; }
    bool IsStarted { get; set; }
    IProductModel Product { get; set; }
    int ProductId { get; set; }
    int StatusId { get; set; }
    DateTime Updated { get; set; }
  }
}