using System;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Models
{
  public interface ICategoryModel
  {
    string ByUser { get; set; }
    int CategoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime Updated { get; set; }
  }
}