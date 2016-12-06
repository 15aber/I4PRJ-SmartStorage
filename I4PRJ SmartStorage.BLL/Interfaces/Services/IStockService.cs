using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface IStockService : IService<StockDto>
  {
    IList<StockDto> GetAllActiveOfInventory(int id);
  }
}
