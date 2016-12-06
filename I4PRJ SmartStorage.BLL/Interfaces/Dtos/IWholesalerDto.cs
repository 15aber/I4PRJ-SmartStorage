using System;

namespace SmartStorage.BLL.Interfaces.Dtos
{
  public interface IWholesalerDto
  {
    string ByUser { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime Updated { get; set; }
    int WholesalerId { get; set; }
  }
}