using System;

namespace SmartStorage.BLL.Interfaces.Dtos
{
  public interface IInventoryDto
  {
    string ByUser { get; set; }
    int InventoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime Updated { get; set; }
  }
}