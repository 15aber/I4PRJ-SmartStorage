using SmartStorage.DAL.Context.Application;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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
      return base.Context.Set<Status>().Include("Inventory").Include("Product").ToList();
    }
    public new List<Status> GetAll(Expression<Func<Status, bool>> predicate)
    {
      return base.Context.Set<Status>().Where(predicate).Include("Inventory").Include("Product").Include("Product.Category").ToList();
    }
  }
}
