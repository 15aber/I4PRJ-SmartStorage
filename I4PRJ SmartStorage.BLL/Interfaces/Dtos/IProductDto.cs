using System;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.BLL.Interfaces.Dtos
{
  public interface IProductDto
  {
    string ByUser { get; set; }
    ICategory Category { get; set; }
    int CategoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    int ProductId { get; set; }
    double PurchasePrice { get; set; }
    ISupplier Supplier { get; set; }
    int SupplierId { get; set; }
    DateTime Updated { get; set; }
    IWholesaler Wholesaler { get; set; }
    int WholesalerId { get; set; }
  }
}