using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartStorage.DAL.Repositories
{
  public class WholesalersRepository : Repository<Wholesaler>, IWholesalersRepository
  {
    public WholesalersRepository(IApplicationDbContext context) : base(context)
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
