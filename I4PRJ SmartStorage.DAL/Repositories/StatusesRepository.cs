using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class StatusesRepository : Repository<Status>, IStatusesRepository
  {
    public StatusesRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }
  }
}
