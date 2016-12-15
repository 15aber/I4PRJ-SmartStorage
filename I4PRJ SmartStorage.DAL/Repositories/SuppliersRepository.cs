using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartStorage.DAL.Repositories
{
  public class SuppliersRepository : Repository<Supplier>, ISuppliersRepository
  {
    public SuppliersRepository(IApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

    public IEnumerable<Supplier> GetAllActiveSuppliers()
    {
      return Context.Set<Supplier>().Where(c => c.IsDeleted == false).ToList();
    }
  }
}
