using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface IWholesalerService : IService<WholesalerDto>
  {
    void Delete(int id);
    List<WholesalerDto> GetAllActive();
  }
}