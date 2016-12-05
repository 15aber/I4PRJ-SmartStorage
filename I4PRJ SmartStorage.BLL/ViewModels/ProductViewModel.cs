using System.Collections.Generic;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.ViewModels
{
  public class ProductViewModel
  {
    public List<ICategoryModel> Categories { get; set; }
    public List<ISupplierModel> Suppliers { get; set; }
    public List<IWholesalerModel> Wholesalers { get; set; }
    public List<IProductModel> Products { get; set; }
    public IProductModel Product { get; set; }
    public int CategoryId { get; set; }
  }
}