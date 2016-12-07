using SmartStorage.DAL.Models;
using System.Collections.Generic;

namespace SmartStorage.DAL.Interfaces.Repositories
{
  public interface IStocksRepository : IRepository<Stock>
  {
    List<Stock> GetAllOfInventory(int id);
  }
}