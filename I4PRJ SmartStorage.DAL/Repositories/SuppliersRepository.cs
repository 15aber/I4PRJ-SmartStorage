using System.Collections.Generic;
using System.Linq;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Repositories
{
  public class SuppliersRepository : Repository<Supplier>, ISuppliersRepository
  {
    public SuppliersRepository(ApplicationDbContext context) : base(context)
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
