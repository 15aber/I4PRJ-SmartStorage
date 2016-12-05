using I4PRJ_SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface ISupplierService : IService<SupplierDto>
  {
    void Delete(int id);
    IList<SupplierDto> GetAllActive();
  }
}
