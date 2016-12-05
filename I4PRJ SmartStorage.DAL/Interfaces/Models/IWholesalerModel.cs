using System;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Models
{
  public interface IWholesalerModel
  {
    string ByUser { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime Updated { get; set; }
    int WholesalerId { get; set; }
  }
}