using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.UI.ViewModels
{
  public class ProductEditModel
  {
    public List<CategoryDto> Categories { get; set; }
    public List<SupplierDto> Suppliers { get; set; }
    public List<WholesalerDto> Wholesalers { get; set; }
    public ProductDto Product { get; set; }
  }
}
