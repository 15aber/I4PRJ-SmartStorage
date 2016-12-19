using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using SmartStorage.DAL.Context.Application;

namespace SmartStorage.DAL.Repositories
{
  public class StatusesRepository : Repository<Status>, IStatusesRepository
  {
    public StatusesRepository(IApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

    public new List<Status> GetAll()
    {
      return Context.Set<Status>().Include("Inventory").Include("Product").ToList();
    }
  }
}
