using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartStorage.DAL.Repositories
{
  public class TransactionsRepository : Repository<Transaction>, ITransactionsRepository
  {
    public TransactionsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

    public new List<Transaction> GetAll()
    {
      return base.Context.Set<Transaction>().Include("FromInventory").Include("ToInventory").Include("Product").ToList();
    }
  }
}
