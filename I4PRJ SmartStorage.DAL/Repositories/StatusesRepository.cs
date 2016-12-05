using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class StatusesRepository : Repository<StatusModel>, IStatusesRepository
  {
    public StatusesRepository(SmartStorageContext context) : base(context)
    {
    }

    public SmartStorageContext SmartStorageContext
    {
      get { return Context as SmartStorageContext; }
    }
  }
}
