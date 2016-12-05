using System;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Models
{
  public interface IProductModel
  {
    string ByUser { get; set; }
    ICategoryModel Category { get; set; }
    int CategoryId { get; set; }
    bool IsDeleted { get; set; }
    string Name { get; set; }
    int ProductId { get; set; }
    double PurchasePrice { get; set; }
    ISupplierModel Supplier { get; set; }
    int SupplierId { get; set; }
    DateTime Updated { get; set; }
    IWholesalerModel Wholesaler { get; set; }
    int WholesalerId { get; set; }
  }
}