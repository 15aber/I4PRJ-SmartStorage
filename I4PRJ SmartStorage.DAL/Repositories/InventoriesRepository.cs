using System.Collections.Generic;
using System.Linq;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class InventoriesRepository : Repository<InventoryModel>, IInventoriesRepository
  {
    public InventoriesRepository(SmartStorageContext context) : base(context)
    {
    }

    public SmartStorageContext SmartStorageContext
    {
      get { return Context as SmartStorageContext; }
    }

    public IEnumerable<InventoryModel> GetAllActiveInventories()
    {
      return Context.Set<InventoryModel>().Where(c => c.IsDeleted == false).ToList();
    }
  }
}
