using System;

namespace SmartStorage.DAL.Interfaces.Models
{
  public interface ISupplier
  {
    string ByUser { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    int SupplierId { get; set; }
    DateTime? Updated { get; set; }
  }
}