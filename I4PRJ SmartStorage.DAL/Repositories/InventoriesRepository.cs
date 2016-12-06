using System.Collections.Generic;
using System.Linq;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Repositories
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
