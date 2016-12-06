using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface ICategoryService : IService<CategoryDto>
  {
    void Delete(int id);
    IList<CategoryDto> GetAllActive();
  }
}
