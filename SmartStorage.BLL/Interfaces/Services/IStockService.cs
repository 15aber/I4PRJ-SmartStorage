using SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface IStockService : IService<StockDto>
  {
    IList<StockDto> GetAllOfInventory(int id);
  }
}
