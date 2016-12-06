using System;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Interfaces.Models
{
  public interface IProduct
  {
    string ByUser { get; set; }
    Category Category { get; set; }
    int CategoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    int ProductId { get; set; }
    double PurchasePrice { get; set; }
    Supplier Supplier { get; set; }
    int SupplierId { get; set; }
    DateTime? Updated { get; set; }
    Wholesaler Wholesaler { get; set; }
    int WholesalerId { get; set; }
  }
}