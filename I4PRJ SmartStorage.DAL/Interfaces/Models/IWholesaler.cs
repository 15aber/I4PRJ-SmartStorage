using System;

namespace SmartStorage.DAL.Interfaces.Models
{
  public interface IWholesaler
  {
    string ByUser { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    DateTime? Updated { get; set; }
    int WholesalerId { get; set; }
  }
}