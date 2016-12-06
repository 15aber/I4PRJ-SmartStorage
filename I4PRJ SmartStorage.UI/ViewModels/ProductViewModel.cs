using System.Collections.Generic;
using I4PRJ_SmartStorage.BLL.Dtos;
using I4PRJ_SmartStorage.BLL.Interfaces.Dtos;

namespace I4PRJ_SmartStorage.UI.ViewModels
{
  public class ProductViewModel
  {
    public IList<CategoryDto> Categories { get; set; }
    public IList<SupplierDto> Suppliers { get; set; }
    public IList<WholesalerDto> Wholesalers { get; set; }
    public IProductDto Product { get; set; }
  }
}