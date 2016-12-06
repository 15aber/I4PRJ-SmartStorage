using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Repositories
{
  public class StocksRepository : Repository<Stock>, IStocksRepository
  {
    public StocksRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }
  }
}
