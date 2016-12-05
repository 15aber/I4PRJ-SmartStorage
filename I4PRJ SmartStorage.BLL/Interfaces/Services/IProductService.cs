using I4PRJ_SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface IProductService : IService<ProductDto>
  {
    void Delete(int id);
    IList<ProductDto> GetAllActive();
    IList<ProductDto> GetAllActiveOfCategory(int id);
  }
}
