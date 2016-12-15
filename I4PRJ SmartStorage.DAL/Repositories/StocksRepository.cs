using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartStorage.DAL.Repositories
{
  public class StocksRepository : Repository<Stock>, IStocksRepository
  {
    public StocksRepository(IApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

    public new List<Stock> GetAll()
    {
      return base.Context.Set<Stock>().Include("Inventory").Include("Product").ToList();
    }

    public List<Stock> GetAllOfInventory(int id)
    {
      return base.Context.Set<Stock>().Include("Inventory").Include("Product").Where(i => i.InventoryId == id).ToList();
    }
  }
}
