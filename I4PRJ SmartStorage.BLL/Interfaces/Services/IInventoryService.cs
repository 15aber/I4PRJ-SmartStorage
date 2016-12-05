using I4PRJ_SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface IInventoryService : IService<InventoryDto>
  {
    void Delete(int id);
    IList<InventoryDto> GetAllActive();
  }
}
