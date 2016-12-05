using I4PRJ_SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface IStockService : IService<StockDto>
  {
    IList<StockDto> GetAllActiveOfInventory(int id);
  }
}
