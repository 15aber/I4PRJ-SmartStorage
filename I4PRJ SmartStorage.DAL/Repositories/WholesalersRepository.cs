using System.Collections.Generic;
using System.Linq;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class WholesalersRepository : Repository<Wholesaler>, IWholesalersRepository
  {
    public WholesalersRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

    public IEnumerable<Wholesaler> GetAllActiveWholesalers()
    {
      return Context.Set<Wholesaler>().Where(c => c.IsDeleted == false).ToList();
    }
  }
}
