using System;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Models
{
  public interface ISupplierModel
  {
    string ByUser { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    int SupplierId { get; set; }
    DateTime Updated { get; set; }
  }
}