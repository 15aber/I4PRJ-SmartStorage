using SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace SmartStorage.BLL.ViewModels
{
  public class ProductEditModel
  {
    public List<CategoryDto> Categories { get; set; }
    public List<SupplierDto> Suppliers { get; set; }
    public List<WholesalerDto> Wholesalers { get; set; }
    public ProductDto Product { get; set; }
  }
}
