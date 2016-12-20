using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface IProductService : IService<ProductDto>
  {
    void Delete(int id);
    IList<ProductDto> GetAllActive();
    IList<ProductDto> GetAllActiveOfCategory(int id);
    IList<ProductDto> GetAllActiveOfInventory(int id);
  }
}
