using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface ISupplierService : IService<SupplierDto>
  {
    void Delete(int id);
    List<SupplierDto> GetAllActive();
  }
}
