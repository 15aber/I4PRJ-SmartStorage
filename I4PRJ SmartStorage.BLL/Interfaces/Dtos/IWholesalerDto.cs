using System;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Dtos
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