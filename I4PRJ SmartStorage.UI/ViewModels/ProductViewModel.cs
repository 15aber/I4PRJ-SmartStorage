using System.Collections.Generic;
using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Dtos;

namespace SmartStorage.UI.ViewModels
{
  public class ProductViewModel
  {
    public IList<CategoryDto> Categories { get; set; }
    public IList<SupplierDto> Suppliers { get; set; }
    public IList<WholesalerDto> Wholesalers { get; set; }
    public IProductDto Product { get; set; }
  }
}