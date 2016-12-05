using I4PRJ_SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface IWholesalerService : IService<WholesalerDto>
  {
    void Delete(int id);
    IList<WholesalerDto> GetAllActive();
  }
}