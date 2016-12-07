using SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface IStatusService : IService<StatusDto>
  {
    IList<StatusDto> GetAllOfInventory(int id);
  }
}
