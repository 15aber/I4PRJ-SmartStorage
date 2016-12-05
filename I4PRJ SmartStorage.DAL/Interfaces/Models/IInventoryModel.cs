using System;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Models
{
  public interface IInventoryModel
  {
    string ByUser { get; set; }
    int InventoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime Updated { get; set; }
  }
}