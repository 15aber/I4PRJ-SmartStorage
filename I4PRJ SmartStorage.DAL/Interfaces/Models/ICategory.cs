using System;

namespace SmartStorage.DAL.Interfaces.Models
{
  public interface ICategory
  {
    string ByUser { get; set; }
    int CategoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime? Updated { get; set; }
  }
}