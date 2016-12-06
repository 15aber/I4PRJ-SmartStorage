using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface IInventoryService : IService<InventoryDto>
  {
    void Delete(int id);
    IList<InventoryDto> GetAllActive();
  }
}
