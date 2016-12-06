using System.Collections.Generic;
using System.Linq;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Repositories
{
  public class InventoriesRepository : Repository<Inventory>, IInventoriesRepository
  {
    public InventoriesRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

    public IEnumerable<Inventory> GetAllActiveInventories()
    {
      return Context.Set<Inventory>().Where(c => c.IsDeleted == false).ToList();
    }
  }
}
