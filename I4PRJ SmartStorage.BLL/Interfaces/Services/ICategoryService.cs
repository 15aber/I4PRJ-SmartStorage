using I4PRJ_SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface ICategoryService : IService<CategoryDto>
  {
    void Delete(int id);
    IList<CategoryDto> GetAllActive();
  }
}
