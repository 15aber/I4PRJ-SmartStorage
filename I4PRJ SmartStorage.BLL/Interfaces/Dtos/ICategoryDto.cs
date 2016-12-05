using System;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Dtos
{
  public interface ICategoryDto
  {
    string ByUser { get; set; }
    int CategoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime Updated { get; set; }
  }
}